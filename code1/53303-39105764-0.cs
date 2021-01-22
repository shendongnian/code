    public static Uri WithQuery(this Uri uri, object values)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));
        if (values != null)
        {
            var query = string.Join(
                "&", from p in ParseQuery(values)
                     where !string.IsNullOrWhiteSpace(p.Key)
                     let key = HttpUtility.UrlEncode(p.Key.Trim())
                     let value = HttpUtility.UrlEncode(p.Value?.ToString())
                     orderby key
                     select value != null ? $"{key}={value}" : key);
            if (query.Length > 0)
                uri = new UriBuilder(uri) { Query = query }.Uri;
        }
        return uri;
    }
