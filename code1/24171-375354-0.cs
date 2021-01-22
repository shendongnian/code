    public static class UriExtensions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            string newUrl = uri.OriginalString;
            if (newUrl.EndsWith("&") || newUrl.EndsWith("?"))
                newUrl = string.Format("{0}{1}={2}", newUrl, name, value);
            else if (newUrl.Contains("?"))
                newUrl = string.Format("{0}&{1}={2}", newUrl, name, value);
            else
                newUrl = string.Format("{0}?{1}={2}", newUrl, name, value);
            return new Uri(newUrl);
        }
    }
