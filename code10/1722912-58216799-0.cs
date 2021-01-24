    public class Program
    {
        public interface IHttpClientFactory
        {
            HttpClient CreateClientWithProxy(IWebProxy webProxy);
        }
        internal class HttpClientFactory : IHttpClientFactory
        {
            private readonly Func<HttpClientHandler> makeHandler;
            public HttpClientFactory(Func<HttpClientHandler> makeHandler)
            {
                this.makeHandler = makeHandler;
            }
            public HttpClient CreateClientWithProxy(IWebProxy webProxy)
            {
                var handler = this.makeHandler();
                handler.Proxy = webProxy;
                return new HttpClient(handler, true);
            }
        }
        internal class CachedHttpClientFactory : IHttpClientFactory
        {
            private readonly IHttpClientFactory httpClientFactory;
            private readonly Dictionary<int, HttpClient> cache = new Dictionary<int, HttpClient>();
            public CachedHttpClientFactory(IHttpClientFactory httpClientFactory)
            {
                this.httpClientFactory = httpClientFactory;
            }
            public HttpClient CreateClientWithProxy(IWebProxy webProxy)
            {
                var key = webProxy.GetHashCode();
                lock (this.cache)
                {
                    if (this.cache.ContainsKey(key))
                    {
                        return this.cache[key];
                    }
                    var result = this.httpClientFactory.CreateClientWithProxy(webProxy);
                    this.cache.Add(key, result);
                    return result;
                }
            }
        }
        public static void Main(string[] args)
        {
            var httpClientFactory = new HttpClientFactory(() => new HttpClientHandler
            {
                UseCookies = true,
                UseDefaultCredentials = true,
            });
            var cachedhttpClientFactory = new CachedHttpClientFactory(httpClientFactory);
            var proxies = new[] {
                new WebProxy()
                {
                    Address = new Uri("https://contoso.com"),
                },
                new WebProxy()
                {
                    Address = new Uri("https://microsoft.com"),
                },
            };
            foreach (var item in proxies)
            {
                var client = cachedhttpClientFactory.CreateClientWithProxy(item);
                client.GetAsync("http://someAddress.com");
            }
        }
    }
