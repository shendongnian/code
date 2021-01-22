    class Program
    {
        static void Main()
        {
            var shows = GetSourceForMyShowsPage();
            Console.WriteLine(shows);
        }
    
        static string GetSourceForMyShowsPage()
        {
            using (var client = new WebClientEx())
            {
                var values = new NameValueCollection
                {
                    { "login_name", "xxx" },
                    { "login_pass", "xxxx" },
                };
                // Authenticate
                client.UploadValues("http://www.tvrage.com/login.php", values);
                // Download desired page
                return client.DownloadString("http://www.tvrage.com/mytvrage.php?page=myshows");
            }
        }
    }
    /// <summary>
    /// A custom WebClient featuring a cookie container
    /// </summary>
    public class WebClientEx : WebClient
    {
        public CookieContainer CookieContainer { get; private set; }
    
        public WebClientEx()
        {
            CookieContainer = new CookieContainer();
        }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = CookieContainer;
            }
            return request;
        }
    }
