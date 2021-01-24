    using System;
    using System.IO;
    using System.Windows.Forms;
    using Gecko;    
    namespace Example6
    {
        static class Example6
        {
            private static GeckoWebBrowser _browser;        
    
            [STAThread]
            static void Main()
            {
                // Don't use XULRunnerLocator.GetXULRunnerLocation() in production software.
                string firefox14Path = XULRunnerLocator.GetXULRunnerLocation();
                Xpcom.Initialize(firefox14Path);
    
                var form = new Form();
                _browser = new GeckoWebBrowser { Dock = DockStyle.Fill };
                _browser.Navigating += InstallCustomEventListener;
                _browser.Navigating += ListenForFakeNavigationMessages;
                
                _browser.Navigate("file://" + Path.Combine(Environment.CurrentDirectory, "Example6.html"));
    
                form.Controls.Add(_browser);
                Application.Run(form);
            }
    
            #region Hatton method
            static void InstallCustomEventListener(object sender, GeckoNavigatingEventArgs e)
            {
                _browser.Navigating -= InstallCustomEventListener;
                _browser.AddMessageEventListener("callMe", ((string p) =>
                    MessageBox.Show(String.Format("C# : Got Message '{0}' from javascript", p))));
            }
            #endregion
    
            #region location changed method
            static void ListenForFakeNavigationMessages(object sender, GeckoNavigatingEventArgs e)
            {
                const string id = "http://somehost//someevent.php?";
                var uri = e.Uri.AbsoluteUri;
                if (uri.Contains(id))
                {
                    MessageBox.Show(String.Format("C# : Got Message '{0}' from javascscript", uri.Substring(id.Length)));
    
                    // This is a fake navigating event - cancel it.
                    e.Cancel = true;
                }
            }
            #endregion
        }
    }
