    public class Browse
    {
        private static AxWebBrowser wBrowser;         
        public static Result StartBrowse(string url)
        {
            var validUri = (url.Contains("http://") ? url : "http://" + url);
            wBrowser = new AxWebBrowser();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AxWebBrowser));
            
            ((ISupportInitialize) (wBrowser)).BeginInit();
            wBrowser.OcxState = ((AxHost.State)(resources.GetObject("wBrowser.OcxState")));
            wBrowser.NewWindow2 += wBrowser_NewWindow2;
            wBrowser.NewWindow3 += wBrowser_NewWindow3;
            wBrowser.DocumentComplete += wBrowser_DocumentComplete;
            wBrowser.DownloadComplete += wBrowser_DownloadComplete;
            if (string.IsNullOrEmpty(html) || validUri != url)
            {
                object empty = System.Reflection.Missing.Value;
                wBrowser.Silent = true;
                wBrowser.Navigate(validUri, ref empty, ref empty, ref empty, ref empty);
            }
            return null;
        }
        static void wBrowser_DownloadComplete(object sender, EventArgs e)
        {
            doAlgorithm();
        }
        static void wBrowser_DocumentComplete(object sender, DWebBrowserEvents2_DocumentCompleteEvent e)
        {
            doAlgorithm();
        }
        static void wBrowser_NewWindow3(object sender, DWebBrowserEvents2_NewWindow3Event e)
        {
            e.cancel = true;
        }
        static void wBrowser_NewWindow2(object sender, DWebBrowserEvents2_NewWindow2Event e)
        {
            e.cancel = true;
        }
    }
