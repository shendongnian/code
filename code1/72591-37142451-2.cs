    [System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
    static extern bool InternetGetCookieEx(string pchURL, string pchCookieName,
        System.Text.StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
    const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
    private string GetGlobalCookies(string uri)
    {
        uint uiDataSize = 2048;
        var sbCookieData = new System.Text.StringBuilder((int)uiDataSize);
        if (InternetGetCookieEx(uri, null, sbCookieData, ref uiDataSize,
                INTERNET_COOKIE_HTTPONLY, IntPtr.Zero)
            &&
            sbCookieData.Length > 0)
        {
            return sbCookieData.ToString().Replace(";", ",");
        }
        return null;
    }
