    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CefSharp;
    using CefSharp.WinForms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                InitializeChromium();
            }
            List<string> classList = new List<string>();
            public ChromiumWebBrowser chromeBrowser;
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
            private void InitializeChromium()
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
                chromeBrowser = new ChromiumWebBrowser("https://en.wikipedia.org/wiki/Main_Page");
                this.panel1.Controls.Add(chromeBrowser);
                chromeBrowser.Dock = DockStyle.Fill;
    
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                Cef.Shutdown();
            }
            public string extract;
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                string EvaluateJavaScriptResult;
                var frame = chromeBrowser.GetMainFrame();
                var task = frame.EvaluateScriptAsync("(function() { return document.getElementById('searchInput').value; })();", null);
    
                task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        var response = t.Result;
                        EvaluateJavaScriptResult = response.Success ? (response.Result.ToString() ?? "null") : response.Message;
                        MessageBox.Show(EvaluateJavaScriptResult);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
    
    
    
    
    
            }
    
    
        }
    }
