    public class MyNotAssumingHttp11ProxiesAndServersProxy : MyWS
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
          HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
          request.ProtocolVersion = HttpVersion.Version10;
          return request;
        }
    }
