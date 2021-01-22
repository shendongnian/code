    public static class HTTP
    {
        public static string GetHeaderString(HttpRequestHeader header)
        {
            // Use a dictionary here if you want. The API is the important bit
            switch (header)
            {
                case HttpRequestHeader.Accept: return "Accept";
                case HttpRequestHeader.AcceptCharset: return "Accept-Charset";
                default: throw new KeyNotFoundException(header.ToString());
            }
        }
    }
