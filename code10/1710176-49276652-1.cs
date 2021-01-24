    public class ResourceProvider
    {
        private readonly ConcurrentDictionary<string, ValueTask<string>> cachedResources
            = new ConcurrentDictionary<string, ValueTask<string>>();
    
        public ValueTask<string> GetResource(string url)
            => this.cachedResources.GetOrAdd(
                url,
                u => new ValueTask<string>(new HttpClient().GetStringAsync(u)));
    }
