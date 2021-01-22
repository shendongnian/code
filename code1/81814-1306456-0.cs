    public bool Connect() {
       if (string.IsNullOrEmpty(_Username)) { base.ThrowHelper(new SessionException("Username not specified.")); } 
       if (string.IsNullOrEmpty(_Password)) { base.ThrowHelper(new SessionException("Password not specified.")); }
    
       _Cookies = new CookieContainer();
       HtmlWeb webFetcher = new HtmlWeb();
       webFetcher.UsingCache = false;
       webFetcher.UseCookies = true;
    
       HtmlWeb.PreRequestHandler justSetCookies = delegate(HttpWebRequest webRequest) {
          SetRequestHeaders(webRequest, false);
          return true;
       };
       HtmlWeb.PreRequestHandler postLoginInformation = delegate(HttpWebRequest webRequest) {
          SetRequestHeaders(webRequest, false);
    
          // before we let webGrabber get the response from the server, we must POST the login form's data
          // This posted form data is *VERY* specific to the web site in question, and it must be exactly right,
          // and exactly what the remote server is expecting, otherwise it will not work!
          //
          // You need to use an HTTP proxy/debugger such as Fiddler in order to adequately inspect the 
          // posted form data. 
          ASCIIEncoding encoding = new ASCIIEncoding();
          string postDataString = string.Format("edit%5Bname%5D={0}&edit%5Bpass%5D={1}&edit%5Bform_id%5D=user_login&op=Log+in", _Username, _Password);
          byte[] postData = encoding.GetBytes(postDataString);
          webRequest.ContentType = "application/x-www-form-urlencoded";
          webRequest.ContentLength = postData.Length;
          webRequest.Referer = Util.MakeUrlCore("/user"); // builds a proper-for-this-website referer string
    
          using (Stream postStream = webRequest.GetRequestStream()) {
             postStream.Write(postData, 0, postData.Length);
             postStream.Close();
          }
    
          return true;
       };
    
       string loginUrl = Util.GetUrlCore(ProjectUrl.Login); 
       bool atEndOfRedirects = false;
       string method = "POST";
       webFetcher.PreRequest = postLoginInformation;
    
       // this is trimmed...this was trimmed in order to handle one of those 'interesting' 
       // login processes...
       webFetcher.PostResponse = delegate(HttpWebRequest webRequest, HttpWebResponse response) {
          if (response.StatusCode == HttpStatusCode.Found) {
             // the login process is forwarding us on...update the URL to move to...
             loginUrl = response.Headers["Location"] as String;
             method = "GET";
             webFetcher.PreRequest = justSetCookies; // we only need to post cookies now, not all the login info
          } else {
             atEndOfRedirects = true;
          }
    
          foreach (Cookie cookie in response.Cookies) {
             // *snip*
          }
       };
    
       // Real work starts here:
       HtmlDocument retrievedDocument = null;
       while (!atEndOfRedirects) {
          retrievedDocument = webFetcher.Load(loginUrl, method);
       }
    
    
       // ok, we're fully logged in.  Check the returned HTML to see if we're sitting at an error page, or
       // if we're successfully logged in.
       if (retrievedDocument != null) {
          HtmlNode errorNode = retrievedDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'error')]");
          if (errorNode != null) { return false; }
       }
    
       return true; 
    }
    
    
    public void SetRequestHeaders(HttpWebRequest webRequest) { SetRequestHeaders(webRequest, true); }
    public void SetRequestHeaders(HttpWebRequest webRequest, bool allowAutoRedirect) {
       try {
          webRequest.AllowAutoRedirect = allowAutoRedirect;
          webRequest.CookieContainer = _Cookies;
    
          // the rest of this stuff is just to try and make our request *look* like FireFox. 
          webRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.3) Gecko/20070309 Firefox/2.0.0.3";
          webRequest.Accept = @"text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
          webRequest.KeepAlive = true;
          webRequest.Headers.Add(@"Accept-Language: en-us,en;q=0.5");
          //webRequest.Headers.Add(@"Accept-Encoding: gzip,deflate");
       }
       catch (Exception ex) { base.ThrowHelper(ex); }
    }
