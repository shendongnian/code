    public class Example
    {
        protected readonly Task<HttpClient> _client; //Injected
        public Example(Task<HttpClient> client)
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
