    using System.Net.Http;
    class Program
    {
       static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync("https://www.google.com").Result;
        }
    }
