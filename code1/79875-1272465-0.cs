    public partial class Service1
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest) base.GetWebRequest(uri);
            request.SendChunked = false;
            return request;
        }
    }
