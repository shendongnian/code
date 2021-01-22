    public partial class Service1Proxy 
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest) base.GetWebRequest(uri);
            request.SendChunked = false;
            return request;
        }
    }
