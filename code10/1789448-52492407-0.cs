        static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.example.com"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");
                    request.Content = new StringContent("{\"username\":\"user\",\"password\":\"pass\"}", Encoding.UTF8, "application/json");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    Console.WriteLine(response);
                    Console.ReadKey();
                }
            }
        }
