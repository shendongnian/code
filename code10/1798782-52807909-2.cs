        //put this code in your MainActivity.cs
        public override bool OnKeyDown(Android.Views.Keycode keyCode, KeyEvent e)
        {
            if (e.KeyCode == Android.Views.Keycode.Back)
            {
                switch (_viewPager.CurrentItem)
                {
                    case 0:
                        _fm1.WebViewGoBack();
                        break;
                    case 1:
                        _fm2.WebViewGoBack();
                        break;
                    case 2:
                        _fm3.WebViewGoBack();
                        break;
                    case 3:
                        _fm4.WebViewGoBack();
                        break;
                    case 4:
                        _fm5.WebViewGoBack();
                        break;
                }
            }
            return false;
        }
then in a fragment instantiate `WebView` assign in `OnCreate` and create a method for going back inside `Fragment` :
        protected static WebView _wv;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.TheFragmentLayout1, container, false);
            _wv = _view.FindViewById<WebView>(Resource.Id.webView1);
         //lots of code         
        }
        public void WebViewGoBack()
        {
            if (_wv.CanGoBack())
                _wv.GoBack();
        }
