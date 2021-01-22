    class BrowserSession{
       private bool _isPost;
       private HtmlDocument _htmlDoc;
       public CookieContainer cookiePot;   //<- This is the new CookieContainer
     ...
        public string Get2(string url)
        {
            HtmlWeb web = new HtmlWeb();
            web.UseCookies = true;
            web.PreRequest = new HtmlWeb.PreRequestHandler(OnPreRequest2);
            web.PostResponse = new HtmlWeb.PostResponseHandler(OnAfterResponse2);
            HtmlDocument doc = web.Load(url);
            return doc.DocumentNode.InnerHtml;
        }
        public bool OnPreRequest2(HttpWebRequest request)
        {
            request.CookieContainer = cookiePot;
            return true;
        }
        protected void OnAfterResponse2(HttpWebRequest request, HttpWebResponse response)
        {
            //do nothing
        }
        private void SaveCookiesFrom(HttpWebResponse response)
        {
            if ((response.Cookies.Count > 0))
            {
                if (Cookies == null)
                {
                    Cookies = new CookieCollection();
                }    
                Cookies.Add(response.Cookies);
                cookiePot.Add(Cookies);		//-> add the Cookies to the cookiePot
            }
        }
