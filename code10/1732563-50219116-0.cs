      // declare at the class level
      WebView webview;
      protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new TheWeddingClient());
            web_view.LoadUrl("https://patahapa.com/apps");
        }
