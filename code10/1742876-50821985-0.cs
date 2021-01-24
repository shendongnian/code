    ...
        public class WebViewerNavigationDelegate : WKNavigationDelegate
        {
            public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
            {
               // anything you need to do after the navigation has loaded
            }
        }
        public void SetLink(string link)
        {
            WebViewer = new WKWebView(View.Frame, new WKWebViewConfiguration());
            var url = NSUrlRequest.FromUrl("url");
            WebViewer.NavigationDelegate = new WebViewerNavigationDelegate();
            WebViewer.LoadRequest(url);
        }
