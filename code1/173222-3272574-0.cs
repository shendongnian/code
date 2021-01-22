    public class WebClientEx : WebClient
    {
        private CookieContainer _cookieContainer = new CookieContainer();
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = _cookieContainer;
            }
            return request;
        }
    }
    
    class Program
    {
        static void Main()
        {
            using (var client = new WebClientEx())
            {
                var response1 = client.DownloadString("https://myJazzServer.com:9092/jazz/authenticated/identity");
    
                var data = new NameValueCollection
                {
                    { "j_username", "myUser" },
                    { "j_password", "MyPass" },
                };
                var response2 = client.UploadValues("https://myJazzServer.com:9092/jazz/authenticated/j_security_check", data);
                Console.WriteLine(Encoding.Default.GetString(response2));
            }
        }
    }
