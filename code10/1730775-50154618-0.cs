    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var content = new StringContent("Hi");
            while (true)
            {
                here:
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://httpbin.org/post"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                try
                {
                    var response = client.SendAsync(request).Result;
                }
                catch (Exception e)
                {
                    goto here;
                }
            }
        }
    }
