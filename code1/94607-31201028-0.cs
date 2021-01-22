    // import .. use a internal static class like "Native" ;)
    [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
    internal static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
    // usage
    string userAgent = "Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_3 like Mac OS X; en-us)";
    
    UrlMkSetSessionOption(0x10000002, null, 0, 0);
    
    UrlMkSetSessionOption(0x10000001, userAgent, userAgent.Length, 0);
