    public class MyWebClient : WebClient
    {
        private CookieContainer _cookieContainer;
        private string _userAgent;
        private int _timeout;
        private WebReponse _response;
        public MyWebClient()
        {
            this._cookieContainer = new CookieContainer();
            this.SetTimeout(60 * 1000);
        }
        public MyWebClient SetTimeout(int timeout)
        {
            this.Timeout = timeout;
            return this;
        }
        public WebResponse Response
        {
            get { return this._response; }
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request.GetType() == typeof(HttpWebRequest))
            {
                ((HttpWebRequest)request).CookieContainer = this._cookieContainer;
                ((HttpWebRequest)request).UserAgent = this._userAgent;
                ((HttpWebRequest)request).Timeout = this._timeout;
            }
            this._request = request;
            return request;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            this._response = base.GetWebResponse(request);
            return this._response;
        }
        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            this._response = base.GetWebResponse(request, result);
            return this._response;
        }
        public MyWebClient ServerCertValidation(bool validate)
        {
            if (!validate) ServicePointManager.ServerCertificateValidationCallback += delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            return this;
        }
    }
