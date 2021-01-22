    private int mFrameCount;
    private void startNavigate(string url) {
      mFrameCount = 0;
      webBrowser1.Navigate(url);
    }
    private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
      mFrameCount += 1;
      bool done = true;
      if (webBrowser1.Document != null) {
        HtmlWindow win = webBrowser1.Document.Window;
        if (win.Frames.Count > mFrameCount && win.Frames.Count > 0) done = false;
      }
      if (done) {
        Console.WriteLine("Now it is really done");
      }
    }
