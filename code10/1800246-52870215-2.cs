        public class MyOnTabChangedListener : Java.Lang.Object, IOnTabChangeListener
        {
            TabHost tabHost;
            public MyOnTabChangedListener(TabHost tabHost)
            {
                this.tabHost = tabHost;
            }
            public void OnTabChanged(string tabId)
            {
                if(tabId == "whats_on")
                {
                    var parentView = ((ViewGroup)((ViewGroup)tabHost.GetChildAt(0)).GetChildAt(1)).GetChildAt(0);                    
                    WebView whatsOnWebView = parentView.FindViewById<WebView>(Resource.Id.webViewWhatsOn);
                    whatsOnWebView.Reload();
                }
            }
        }
