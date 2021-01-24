    using DotNetBrowser;
    using DotNetBrowser.WinForms;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WinFormsSampleCSLightweight
    {
        public partial class Form1 : Form
        {
            private readonly BrowserView browserView;
            public Form1()
            {
                InitializeComponent();
                browserView = new WinFormsBrowserView(BrowserFactory.Create(BrowserType.LIGHTWEIGHT));
                Controls.Add((Control)browserView);
                browserView.Browser.LoadURL("http://www.google.com");
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (browserView != null)
                {
                    browserView.Dispose();
                    browserView.Browser.Dispose();
                }
            }
        }
    }
