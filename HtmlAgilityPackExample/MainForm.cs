using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

//Author: Nikolai Kekish
//Web: http://mydataprovider.com
//Email: sales@mydataprovider.com

namespace HtmlAgilityPackExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //http://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=iphone+6s
            try
            {
                textBoxOutput.Text = "";
                var url = "http://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=" + System.Web.HttpUtility.UrlEncode(textBoxInput.Text);
                var client = new WebClient();
                var html = client.DownloadString(url);

                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var a = doc.DocumentNode.SelectSingleNode("//div[@class=\"s-item-container\"]//a");
                if (a != null)
                {
                    textBoxOutput.Text = a.Attributes["href"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = ex.Message;
            }
        }
    }
}
