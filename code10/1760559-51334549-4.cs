    public class Application
    {
        protected readonly Task<HttpClient> _client; //Injected
        public Application(Task<HttpClient> client)
        {
            _client = client;
        }
        public async Task<string> Run()
        {
            var result = await (await _client).GetAsync("http://www.StackOverflow.com");
            var text = await result.Content.ReadAsStringAsync();
            return text;
        }
    }
