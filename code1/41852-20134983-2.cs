    public static class UriHelper
    {
        public static IDictionary<string, string> DecodeQueryParameters(this Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");
            if (uri.Query.Length == 0)
                return new Dictionary<string, string>();
            IEnumerable<string[]> pairs = uri.Query.TrimStart('?')
                                                   .Split('&')
                                                   .Select(kvp => kvp.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries));
            if (pairs.Any(pair => pair.Length != 2))
                throw new FormatException(string.Format("Malformed query string '{0}'.", uri.Query));
            if (pairs.SelectMany(pair => pair).Any(token => token.IndexOfAny(new[] { '?', '=', '&' }) != -1))
                throw new FormatException(string.Format("Malformed query string '{0}'.", uri.Query));
            return pairs.ToDictionary(kvp => kvp[0], kvp => kvp[1]);
        }
    }
