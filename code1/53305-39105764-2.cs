    public static Uri WithQuery(this Uri uri, object values)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));
        if (values != null)
        {
            var query = string.Join(
                "&", from p in ParseQueryValues(values)
                     where !string.IsNullOrWhiteSpace(p.Key)
                     let k = HttpUtility.UrlEncode(p.Key.Trim())
                     let v = HttpUtility.UrlEncode(p.Value)
                     orderby k
                     select !string.IsNullOrEmpty(v) ? $"{k}={v}" : k);
            if (query.Length > 0)
                uri = new UriBuilder(uri) { Query = query }.Uri;
        }
        return uri;
    }
