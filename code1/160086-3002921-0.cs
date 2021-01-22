    public class SocksHttpWebRequest : HttpWebRequest
       
       public static Create( string url, string proxy_url ) {
       ... setup socks connection ...
       // call base HttpWebRequest class Create() with proxy url
       base.Create(proxy_url);
       }
