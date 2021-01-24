    using System;
    using System.Windows.Forms;
    using DotNetBrowser;
    using DotNetBrowser.DOM;
    using DotNetBrowser.Events;
    using DotNetBrowser.WinForms;
    
    namespace WindowsFormsApp9
    {
        class Program
        {
            public class WindowMain : Form
            {
                private WinFormsBrowserView browserView;
    
                public WindowMain()
                {
                    Browser browser = BrowserFactory.Create();
                    browserView = new WinFormsBrowserView(browser);
    
                    browser.FinishLoadingFrameEvent += Browser_FinishLoadingFrameEvent;
    
                    this.Controls.Add(browserView);
    
                    Width = 1024;
                    Height = 768;
                    this.Load += WindowMain_Loaded;
                }
    
                private void Browser_FinishLoadingFrameEvent(object sender, FinishLoadingEventArgs e)
                {
                    if(e.IsMainFrame && e.ValidatedURL.Contains("loginURL"))
                    {
                        DOMDocument document = e.Browser.GetDocument();
                        DOMInputElement username = (DOMInputElement)document.GetElementById("id_Username");
                        DOMInputElement password = (DOMInputElement)document.GetElementById("id_Password");
    
                        username.Value = "fo2";
                        password.Value = "f2342156f";
    
                        e.Browser.FinishLoadingFrameEvent -= Browser_FinishLoadingFrameEvent;
                    }
                }
    
                void WindowMain_Loaded(object sender, EventArgs e)
                {
                    browserView.Browser.LoadURL("http://test.com");
                }
    
                [STAThread]
                public static void Main()
                {
                    WindowMain wnd = new WindowMain();
                    Application.Run(wnd);
    
                    var browser = wnd.browserView.Browser;
                    wnd.browserView.Dispose();
                    browser.Dispose();
                }
            }
        }
    }
