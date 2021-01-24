    public class WhatsOnClickListener : Java.Lang.Object, IOnClickListener
    {
        TabHost tabHost;
        //this int will tell the click listener whether to reload the webview or pop 2 root
        static int tbC = 0;
        public WhatsOnClickListener(TabHost tabHost)
        {
            //tell the clicklistener which tabhost to use
            this.tabHost = tabHost;
        }
        //this class handles the click event
        public void OnClick(View v)
        {
            //declare the webview and tell our object where to find the XAML resource
            WebView webViewWhatsOn = tabHost.CurrentView.FindViewById<WebView>(Resource.Id.webViewWhatsOn);
            //...if the CurrentTab != 0 ... we won't fire the Reload() or LoadUrl() 
            //..without this logic, the app will crash because our WebViews 
            //.aren't set to an instance of an object
            if (tabHost.CurrentTab == 0)
            {
                //if tbC int is 0, we will reload the page
                if (tbC == 0)
                {
                    //tell whatsOnWebView to Reload
                    webViewWhatsOn.Reload();
                    //set the int to one so next time webview will pop to root
                    tbC = 1;
                }
                //else if the int is 1, we will pop to root on tab 0
                else if (tbC == 1)
                {
                    //tell whatsOnWebView to pop to root
                    webViewWhatsOn.LoadUrl(@"https://bitchute.com/");
                    //set the tbC int so that next time webview will reload
                    tbC = 0;
                }
            }
            //if our current tab isn't zero, we need to set CurrentTab to 0
            //this line is critical or our tabs won't work when not selected
            tabHost.CurrentTab = 0;
        }
    }
    public class SubsClickListener : Java.Lang.Object, IOnClickListener
    {
        TabHost tabHost1;
        
        static int tbC = 0;
        public SubsClickListener(TabHost tabHost1)
        {
            this.tabHost1 = tabHost1;
        }
        public void OnClick(View v)
        {
            if (tabHost1.CurrentTab == 1)
            {
                WebView subWebView = tabHost1.CurrentView.FindViewById<WebView>(Resource.Id.webViewSubs);
                if (tbC == 0)
                {
                    subWebView.Reload();
                    tbC = 1;
                }
                else if (tbC == 1)
                {
                    subWebView.LoadUrl(@"https://bitchute.com/subscriptions/");
                    tbC = 0;
                }
            }
            tabHost1.CurrentTab = 1;
        }
    }
