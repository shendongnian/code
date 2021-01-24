    [DllImport("wininet.dll", SetLastError = true)]
    public static extern bool InternetGetCookieEx(
        string url,
        string cookieName,
        StringBuilder cookieData,
        ref int size,
        Int32 dwFlags,
        IntPtr lpReserved);
    private const Int32 InternetCookieHttponly = 0x2000;
    public static String GetUriCookies(String uri)
    {
        // Determine the size of the cookie
        int datasize = 8192 * 16;
        StringBuilder cookieData = new StringBuilder(datasize);
        if (!InternetGetCookieEx(uri, null, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero))
        {
            if (datasize < 0)
                return null;
            // Allocate stringbuilder large enough to hold the cookie
            cookieData = new StringBuilder(datasize);
            if (!InternetGetCookieEx(
                uri,
                null, cookieData,
                ref datasize,
                InternetCookieHttponly,
                IntPtr.Zero))
                return null;
        }
        return cookieData.ToString();
    }
    private void button_Click(object sender, EventArgs e)
    {
        HtmlElement el = webBrowser.Document.GetElementById("myId");
        String url = el.GetAttribute("x-my-data");
        String cookies = GetUriCookies(url);
        WebClient wc = new WebClient();
        wc.Headers.Add("Cookie", cookies);
        wc.Headers.Add("Referer", WEB_APP_URL); // url of webapp base path, http://myhost/MyUI
        byte[] data = wc.DownloadData(url);
    }
