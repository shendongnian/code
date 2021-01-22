    public static class HTTP
    {
        private static readonly Dictionary<HttpRequestHeader, string> Headers =
            new Dictionary<HttpRequestHeader, string>
        {
            ( HttpRequestHeader.Accept, "Accept" ),
            ( HttpRequestHeader.AcceptCharset, "Accept-Charset" )
        };
        public static string GetHeaderString(HttpRequestHeader header)
        {
            return Headers[header];
        }
    }
