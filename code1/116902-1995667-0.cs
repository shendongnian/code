    using System;
    using System.Threading;
    using System.ComponentModel;
    using System.Windows.Forms;
    class WebPagePump : IDisposable {
      public delegate void CompletedCallback(WebBrowser wb);
      private ManualResetEvent mStart;
      private SyncHelper mSyncProvider;
      public event CompletedCallback Completed;
    
      public WebPagePump() {
        // Start the thread, wait for it to initialize
        mStart = new ManualResetEvent(false);
        Thread t = new Thread(startPump);
        t.SetApartmentState(ApartmentState.STA);
        t.IsBackground = true;
        t.Start();
        mStart.WaitOne();
      }
      public void Dispose() {
        // Shutdown message loop and thread
        mSyncProvider.Terminate();
      }
      public void Navigate(Uri url) {
        // Start navigating to a URL
        mSyncProvider.Navigate(url); 
      }
      void mSyncProvider_Completed(WebBrowser wb) {
        // Navigation completed, raise event
        CompletedCallback handler = Completed;
        if (handler != null) handler(wb);
      }
      private void startPump() {
        // Start the message loop
        mSyncProvider = new SyncHelper(mStart);
        mSyncProvider.Completed += mSyncProvider_Completed;
        Application.Run(mSyncProvider);
      }
      class SyncHelper : Form {
        WebBrowser mBrowser = new WebBrowser();
        ManualResetEvent mStart;
        public event CompletedCallback Completed;
        public SyncHelper(ManualResetEvent start) {
          mBrowser.DocumentCompleted += mBrowser_DocumentCompleted;
          mStart = start;
        }
        public void Navigate(Uri url) {
          // Start navigating
          this.BeginInvoke(new Action(() => mBrowser.Navigate(url)));
        }
        void mBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
          // Generated completed event
          Completed(mBrowser);
        }
        public void Terminate() {
          // Shutdown form and message loop
          this.Invoke(new Action(() => this.Close()));
        }
        protected override void SetVisibleCore(bool value) {
          if (!IsHandleCreated) {
            // First-time init, create handle and wait for message pump to run
            this.CreateHandle();
            this.BeginInvoke(new Action(() => mStart.Set()));
          }
          // Keep form hidden
          value = false;
          base.SetVisibleCore(value);
        }
      }
    }
 
