    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest (Uri address)
        {
          WebRequest request = (WebRequest) base.GetWebRequest (address);
          request.Container = new CookieContainer();
          return request;
        }
    }
