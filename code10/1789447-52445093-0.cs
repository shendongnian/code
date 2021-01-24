    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    // Add NuGet package System.Net.Http.Formatting.Extension
    namespace SimpleRestCall
    {
        class Program
        {
            static CancellationTokenSource cts = new CancellationTokenSource();
            
            static readonly string sitePath = "https://example.com";
            static void Main(string[] args)
            {
                using (var client = new HttpClient { BaseAddress = new Uri(sitePath), Timeout = new TimeSpan(0, 1, 0) })
                {
                    Task.Run(() => Login(client)).Wait();
                }
            }
    
            private static async Task Login(HttpClient client)
            {
                string path = ""; // if it's a controller path put it here
                LoginData postData = new LoginData { username = "username", password = "password" };
                string json;
                using (HttpResponseMessage resp = await client.PostAsJsonAsync(path, postData, cts.Token))
                {
                    json = await resp.Content.ReadAsStringAsync();
                }
                Console.WriteLine(json);
                Console.WriteLine("Press a key to finish");
                string aa = Console.ReadLine();
            }
    
            private class LoginData
            {
                public string username { get; set; }
                public string password { get; set; }
            }
        }
    }
