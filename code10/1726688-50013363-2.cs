    public override void LoadingFinished(UIWebView webView)
    {
        var wv = webViewRenderer.Element as AutoWebView;
        if (wv.HeightRequest < 0)
        {
            wv.HeightRequest = (double)webView.ScrollView.ContentSize.Height;
            (wv.Parent.Parent as ViewCell).ForceUpdateSize();
        }
    }
