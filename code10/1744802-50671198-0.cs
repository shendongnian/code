    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace image
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                var bytes = File.ReadAllBytes("/tmp/sample.jpg");
                var base64 = Convert.ToBase64String(bytes);
                var secretKey = "my_key";
                var url = $"http://yoururl.com?my_key={secretKey}";
    
                using(var client = new HttpClient())
                {
                    var content = new StringContent(base64);
                    var response = await client.PostAsync(url, content);
                    var stringResponse = await response.Content.ReadAsStringAsync();
    
                    Console.WriteLine(stringResponse);
                }
            }
        }
    }
