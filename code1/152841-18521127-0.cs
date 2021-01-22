    public class webControlWrapper
    {
        private bool _complete;
        private WebBrowser _webBrowserControl;
        public webControlWrapper(WebBrowser webBrowserControl)
        {
            _webBrowserControl = webBrowserControl;
        }
        public void NavigateAndWaitForComplete(string url)
        {
            _complete = false;
            _webBrowserControl.Navigate(url);
            var webBrowser = (SHDocVw.WebBrowser) _webBrowserControl.ActiveXInstance;
            if (webBrowser != null)
                webBrowser.DocumentComplete += WebControl_DocumentComplete;
            //Wait until page is complete
            while (!_complete)
            {
                Application.DoEvents();
            }
        }
        private void WebControl_DocumentComplete(object pDisp, ref object URL)
        {
            // Test if it's the main frame who called the event.
            if (pDisp == _webBrowserControl.ActiveXInstance)
                _complete = true;
        }
