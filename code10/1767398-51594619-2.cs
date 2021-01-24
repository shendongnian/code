    class Program
    {
        private static HttpClient httpClient;
        static void Main(string[] args)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("your base url");
            // add any default headers here also
            httpClient.Timeout = new TimeSpan(0, 2, 0); // 2 minute timeout
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            await new MyClass(httpClient).StartAsync();
        }
    }
