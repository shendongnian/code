    public static class UriHelper
    {
        public static IDictionary<string, string> DecodeQueryParameters(this Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");
            if (string.IsNullOrWhiteSpace(uri.Query))
                return new Dictionary<string, string>();
            try
            {
                return uri.Query.TrimStart('?')
                                .Split('&')
                                .Select(kvp => kvp.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
                                .ToDictionary(kvp => kvp[0], kvp => kvp[1]);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new FormatException(string.Format("Malformed query string '{0}'.", uri.Query), ex);
            }
        }
    }
