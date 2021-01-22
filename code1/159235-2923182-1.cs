    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    class Program
    {
        public static void Main()
        {
            var urls = new[] { "http://www.google.com", "http://www.yahoo.com" };
    
            Task.Factory.ContinueWhenAll(
                urls.Select(url => Task.Factory.StartNew(u => 
                {
                    using (var client = new WebClient())
                    {
                        return client.DownloadString((string)u);
                    }
                }, url)).ToArray(), 
                tasks =>
                {
                    var results = tasks.Select(t => t.Result);
                    foreach (var html in results)
                    {
                        Console.WriteLine(html);
                    }
            });
            Console.ReadLine();
        }
    }
