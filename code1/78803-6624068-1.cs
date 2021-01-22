        private ManualResetEvent mStart;
        private SiteHelper mSyncProvider;
        public event CompletedCallback Completed;
        public SiteManager()
        {
            // Start the thread, wait for it to initialize
            mStart = new ManualResetEvent(false);
            Thread t = new Thread(startPump);
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
            mStart.WaitOne();
        }
        public void Dispose()
        {
            // Shutdown message loop and thread
            mSyncProvider.Terminate();
        }
        public void Navigate(string url)
        {
            // Start navigating to a URL
            mSyncProvider.Navigate(url);
        }
        public void mSyncProvider_Completed(WebBrowser wb)
        {
            // Navigation completed, raise event
              CompletedCallback handler = Completed;
              if (handler != null)
              {
                  handler(wb);
              }
        }
        private void startPump()
        {
            // Start the message loop
            mSyncProvider = new SiteHelper(mStart);
            mSyncProvider.Completed += mSyncProvider_Completed;
            Application.Run(mSyncProvider);
        }
      
    }
