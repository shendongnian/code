    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run().Wait();
        }
        public async Task Run()
        {
            
            var resources =
                new List<string>
                    {
                        "http://www.google.com"
                        ,"http://www.yahoo.com"
                        ,"http://cnn.com"
                        ,"http://microsoft.com"
                    }
                    .ToObservable()
                    .Select(s => Observable.FromAsync(() => DownloadAsync(s)))
                    .Concat()
                    .Where(w => w.IsSuccessStatusCode)
                    .Select(s => Observable.FromAsync(() => GetResources(s)))
                    .Concat()
                    .Where(w => w.Any())
                    .SelectMany(s => s)
                    .ToEnumerable()
                    .OrderBy(o => o.Name);
            foreach (var re in resources)
            {
                Console.WriteLine(re.Name);
            }
            Console.ReadLine();
        }
        public async Task<HttpResponseMessage> DownloadAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
            return await client.SendAsync(request);
        }
        public async Task<IEnumerable<Resource>> GetResources(HttpResponseMessage message)
        {
            var ignoreContent = await message.Content.ReadAsStringAsync();
            return new List<Resource> { new Resource { Name = message.Headers.Date.ToString() } };
        }
    }
    public class Resource
    {
        public string Name { get; set; }
    }
