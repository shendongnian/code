    using System.Web;
    public static class HttpExtensions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            var ub = new UriBuilder(uri);
            // decodes urlencoded pairs from uri.Query to HttpValueCollection
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);
    
            httpValueCollection.Add(name, value);
            // urlencodes the whole HttpValueCollection
            ub.Query = httpValueCollection.ToString();
    
            return ub.Uri;
        }
    }
