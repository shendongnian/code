        public  WebBrowser SyncronNavigation(string url)
        {
            WebBrowser wb  = null;
            
            wb = new WebBrowser();
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(new Uri(url));
            while (!_autoEvent.WaitOne(100))
                Application.DoEvents();
            return wb;
        }
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            _autoEvent.Set();
        }
