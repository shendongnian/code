    [Activity]
    public class SpeakersActivity : Activity
    {
        
        public class MyOnClickListener : Java.Lang.Object, IOnClickListener
        {
            TabHost tabHost;
            public MyOnClickListener(TabHost tabHost)
            {
                this.tabHost = tabHost;
            }
            public void OnClick(View v)
            {
                WebView subWebView = tabHost.CurrentView.FindViewById<WebView>(Resource.Id.webViewSubs);
                if (subWebView != null)
                {
                    subWebView.Reload();
                }
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set the content view
            SetContentView(Resource.Layout.subs);
            //declare webview and tell our code where to find the XAML resource
            WebView subWebView = FindViewById<WebView>(Resource.Id.webViewSubs);
            //set the webview client
            subWebView.SetWebViewClient(new WebViewClient());
            //load the subscription url
            subWebView.LoadUrl("https://www.bitchute.com/subscriptions/");
            //enable javascript in our webview
            subWebView.Settings.JavaScriptEnabled = true;
            //zoom control on?  This should perhaps be disabled for consistency?
            //we will leave it on for now
            subWebView.Settings.BuiltInZoomControls = true;
            subWebView.Settings.SetSupportZoom(true);
            //scrollbarsdisabled
            // subWebView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            subWebView.ScrollbarFadingEnabled = false;
            //declare our tabhost tab and tell the class where to find resource
            TabHost tab = Parent.FindViewById<TabHost>(Android.Resource.Id.TabHost);
            //GetChildAt(1) means tab two.  So our click listener is listening on tab 2.  
            ((TabActivity)Parent).TabHost.TabWidget.GetChildAt(1).SetOnClickListener(new MyOnClickListener(tab));
        }
    }
