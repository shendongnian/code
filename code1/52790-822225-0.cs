    public static string UrlFullEncode(string strUrl) 
    {
        if (strUrl == null)
            return "";
        strUrl = System.Web.HttpUtility.UrlEncode(strUrl);
    }
