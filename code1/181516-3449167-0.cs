    public class Foo
    {
        private enum CacheKey
        {
            Bar, Baz, ...;
        }
        private readonly XDocument doc;
        private readonly Dictionary<CacheKey, string> cache;
        private string Fetch(CacheKey key, Func<XDocument, string> computation)
        {
            string result;
            if (!cache.TryGetValue(key, out result))
            {
                result = computation(doc);
                cache[key] = result;
            }
            return result;
        }
        public string Bar
        {
            get { return Fetch(CacheKey.Bar, doc => doc.Element("bar").Value); }
        }
    }
