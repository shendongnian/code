    public class MyWebClient : WebClient 
    {
        protected override WebRequest GetWebRequest(Uri address) {
            HttpWebRequest req = (HttpWebRequest)base.GetWebRequest(address);
            req.ServicePoint.ConnectionLimit = 50;
            return (WebRequest)req;
        }
    }
