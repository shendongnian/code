     public class ExtendedWebViewRenderer : WebViewRenderer
            {
    
                private WebViewClient webViewClient = new MyWebViewClient();
                private static Context context;
                private static string SUCCESS_URL = "http://www.rcbazaar.com/PayuReturn.aspx#";
                private static string FAILED_URL = "https://www.payumoney.com/mobileapp/payumoney/failure.php";
                private static string firstname = "Anbu";
                private static string lastname = "AV";
                public string url_s;
    
                private static string email = "anbukm91@gmail.com";
                private static string productInfo = "93314";
                private static string mobile = "8220155182";
                public static string totalAmount = "10.00";
                public ExtendedWebViewRenderer(Context context) : base(context)
                {
                }
                protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
                {
                    try
                    {
                        base.OnElementChanged(e);
                        if (this.Control != null)
                        {
                            var webView = new global::Android.Webkit.WebView(this.Context);
                            var view = (ExtendedWebView)Element;
    
    
                            Control.Settings.JavaScriptEnabled = true;
                            Control.Settings.SetSupportZoom(false);
                            Control.Settings.DomStorageEnabled = true;
                            Control.Settings.LoadWithOverviewMode = true;
                            Control.Settings.UseWideViewPort = true;
                            Control.Settings.CacheMode = CacheModes.NoCache;
                            Control.Settings.SetSupportMultipleWindows(true);
                            Control.Settings.JavaScriptCanOpenWindowsAutomatically = true;
                        Control.AddJavascriptInterface(new PayUJavaScriptInterface(this.Context), "PayUMoney");  //JavaInterface
    
                        url_s = "https://test.payu.in/_payment";
    
    
    
                            Control.PostUrl(url_s, Encoding.UTF8.GetBytes(getPostString()));
    
                            Control.SetWebViewClient(webViewClient);
    
    
                       
    
                        }
                    }
                    catch (System.Exception ex)
                    {
    
                    }
                }
    
                //PostString is Append All parameters 
                public string getPostString()
                {
                    string TxtStr = Generate();
                    string strHash = Generatehash512(TxtStr + DateTime.Now);
                    string txnid = strHash.ToString().Substring(0, 20);
    
                    string key = "W5bPaX";  //Key gtKFFx
                    string salt = "H7b5NDWN"; //salt eCwWELxi
    
    
    
                    Java.Lang.StringBuilder post = new Java.Lang.StringBuilder();
                    Java.Lang.StringBuilder checkSumStr = new Java.Lang.StringBuilder();
    
                    try
                    {
    
                        checkSumStr.Append(key);
                        checkSumStr.Append("|");
                        checkSumStr.Append(txnid);
                        checkSumStr.Append("|");
                        checkSumStr.Append(1);
                        checkSumStr.Append("|");
                        checkSumStr.Append(productInfo);
                        checkSumStr.Append("|");
                        checkSumStr.Append(firstname);
                        checkSumStr.Append("|");
                        checkSumStr.Append(email);
                        checkSumStr.Append("|||||||||||");
                        checkSumStr.Append(salt);
                        var ss = Generatehash512(checkSumStr.ToString());
                        post.Append("key=");
                        post.Append(key);
                        post.Append("&");
                        post.Append("txnid=");
                        post.Append(txnid);
                        post.Append("&");
                        post.Append("amount=");
                        post.Append(1);
                        post.Append("&");
                        post.Append("productinfo=");
                        post.Append(productInfo);
                        post.Append("&");
                        post.Append("firstname=");
                        post.Append(firstname);
                        post.Append("&");
                        post.Append("email=");
                        post.Append(email);
                        post.Append("&");
                        post.Append("phone=");
                        post.Append(mobile);
                        post.Append("&");
                        post.Append("surl=");
                        post.Append(SUCCESS_URL);
                        post.Append("&");
                        post.Append("furl=");
                        post.Append(FAILED_URL);
                        post.Append("&");
                        post.Append("hash=");
                        post.Append(ss);
                    }
                    catch (NoSuchAlgorithmException e1)
                    {
                        // TODO Auto-generated catch block
                        e1.PrintStackTrace();
                    }
                    return post.ToString();
                }
    
    
                //Generate random transaction id
                public string Generate()
                {
    
                    long ticks = System.DateTime.Now.Ticks;
                    System.Threading.Thread.Sleep(200);
                    Java.Util.Random rnd = new Java.Util.Random();
                    string rndm = Integer.ToString(rnd.NextInt()) + (System.DateTime.Now.Ticks - ticks / 1000);
    
                    return rndm;
                }
                //Generating Hash(Checksum) string
                public string Generatehash512(string text)
                {
    
                    byte[] message = Encoding.UTF8.GetBytes(text);
    
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] hashValue;
                    SHA512Managed hashString = new SHA512Managed();
                    string hex = "";
                    hashValue = hashString.ComputeHash(message);
                    foreach (byte x in hashValue)
                    {
                        hex += System.String.Format("{0:x2}", x);
                    }
                    return hex;
    
                }
                //Java Interface After Payment its Return Success/failure
                private class PayUJavaScriptInterface : Java.Lang.Object
                {
                    Context mContext;
                    public PayUJavaScriptInterface(Context c)
                    {
                        mContext = c;
                    }
    
                //public void Success
                [Export]
                [JavascriptInterface]          
                public void success(long id, string paymentId)
                    {
                        Intent intent = new Intent(mContext, typeof(success));
                        mContext.StartActivity(intent);
                    }
    
                [Export]
                [JavascriptInterface]
                public void failure(long id, string paymentId)
                    {
                        Intent intent = new Intent(mContext, typeof(failure));
                        mContext.StartActivity(intent);
                    }
                }
                //WebView Client Run Time
                private class MyWebViewClient : WebViewClient
                {
                    public override void OnPageStarted(Android.Webkit.WebView view, string url, Android.Graphics.Bitmap favicon)
                    {
    
                        base.OnPageStarted(view, url, favicon);
    
                    }
                    public override void OnPageFinished(Android.Webkit.WebView view, string url)
                    {
    
                        base.OnPageFinished(view, url);
    
                    }
    
                    public override void OnReceivedSslError(Android.Webkit.WebView view, SslErrorHandler handler, SslError error)
                    {
                        Log.Info("Error", "Exception caught!");
                        handler.Proceed();
    
                    }
    
    
                }
            }
