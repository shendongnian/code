    internal static Encoding GetFileIOEncoding()
    {
        return Encoding.Default;
    }
    internal static int GetLocaleCodePage()
    {
        return Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage;
    }
