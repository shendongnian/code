    public class CookieAwareWebClient : WebClient
    {
        private CookieContainer cookie = new CookieContainer();
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = cookie;
            }
            return request;
        }
    }
    var client = new CookieAwareWebClient();
    client.BaseAddress = @"https://www.site.com/any/base/url/";
    var loginData = new NameValueCollection();
    loginData.Add("login", "YourLogin");
    loginData.Add("password", "YourPassword");
    client.UploadValues("login.php", "POST", loginData);
    //Now you are logged in and can request pages    
    string htmlSource = client.DownloadString("index.php");
