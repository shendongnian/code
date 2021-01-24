        localWebView.SetWebViewClient(new MyWebViewClient());
        public class MyWebViewClient : WebViewClient
        {
            [Obsolete("deprecated")]
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }
