        public WebBrowser mBrowser = new WebBrowser();
        ManualResetEvent mStart;
        public event CompletedCallback Completed;
        public SiteHelper(ManualResetEvent start)
        {
            mBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(mBrowser_DocumentCompleted);
            mStart = start;
        }
        void mBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Generated completed event
            Completed(mBrowser);
        }
        public void Navigate(string url)
        {
            // Start navigating
            this.BeginInvoke(new Action(() => mBrowser.Navigate(url)));
        }
      
        public void Terminate()
        {
            // Shutdown form and message loop
            this.Invoke(new Action(() => this.Close()));
        }
        protected override void SetVisibleCore(bool value)
        {
            if (!IsHandleCreated)
            {
                // First-time init, create handle and wait for message pump to run
                this.CreateHandle();
                this.BeginInvoke(new Action(() => mStart.Set()));
            }
            // Keep form hidden
            value = false;
            base.SetVisibleCore(value);
        }
    }
