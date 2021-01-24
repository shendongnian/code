        public class MyOnClickListener : Java.Lang.Object, IOnClickListener
        {
            TabHost tabHost;
            public MyOnClickListener(TabHost tabHost)
            {
                this.tabHost = tabHost;
            }
            public void OnClick(View v)
            {
               
                var parentView = ((ViewGroup)((ViewGroup)tabHost.GetChildAt(0)).GetChildAt(1)).GetChildAt(0);
                WebView whatsOnWebView = parentView.FindViewById<WebView>(Resource.Id.webViewWhatsOn);
                whatsOnWebView.Reload();
                tabHost.CurrentTab = 0;
            }
        }
