    public interface ICatalogClientFactory
    {
        ICatalogClient Create(HttpCookieCollection cookies, string catalogUrl);
    }
    public class CatalogClientFactory : ICatalogClientFactory
    {
        public ICatalogClient Create(HttpCookieCollection cookies, string catalogUrl)
        {
            return new CatalogClient(cookies, catalogUrl);
        }
    }
