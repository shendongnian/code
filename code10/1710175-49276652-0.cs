    public class ResourceProvider
    {
        private readonly ConcurrentDictionary<string, Task<string>> cachedResources
            = new ConcurrentDictionary<string, ValueTask<string>>();
    
        public Task<string> GetResource(string url)
            => this.cachedResources.GetOrAdd(url, u => new new HttpClient().GetStringAsync(u));
    }
