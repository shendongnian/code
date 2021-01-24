    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var ignored = base.OnCreateView(inflater, container, savedInstanceState);
        View v = inflater.Inflate(Resource.Layout.fragment1, container, false);
        WebView webView = v.FindViewById<WebView>(Resource.Id.webView);
        webView.LoadUrl("https://google.com");
        webView.Settings.JavaScriptEnabled = true;
        webView.SetWebViewClient(new WebViewClient());
        return inflater.Inflate(Resource.Layout.fragment1, null);
    }
