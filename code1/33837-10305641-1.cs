    class Ejemplo
    {
        static void Main(string[] args)
        {
            string _response = null;
            string _auth = "Basic";
            Uri _uri = new Uri(@"http://api.olr.com/Service.svc");
            string addres = @"http://api.olr.com/Service.svc";
            string proxy = @"http://xx.xx.xx.xx:xxxx";
            string user = @"platinum";
            string pass = @"01CFE4BF-11BA";
            NetworkCredential net = new NetworkCredential(user, pass);
            CredentialCache _cc = new CredentialCache();
            WebCustom page = new WebCustom(addres, proxy);
            page.connectProxy();
            _cc.Add(_uri, _auth, net);
            page.myWebClient.Credentials = _cc;
                
            Console.WriteLine(page.copyWeb());
        }
     
    }
    public class WebCustom
    {
            private string proxy;
            private string url;
            public WebClient myWebClient;
            public WebProxy proxyObj;
            public string webPageData;
       
            public WebCustom(string _url, string _proxy)
            {
                url = _url;
                proxy = _proxy;
                myWebClient = new WebClient();
            }
            public void connectProxy()
            {
                proxyObj = new WebProxy(proxy, true);
                proxyObj.Credentials = CredentialCache.DefaultCredentials;
                myWebClient.Proxy = proxyObj;
            }
            public string copyWeb()
            { return webPageData = myWebClient.DownloadString(url); }
    }
