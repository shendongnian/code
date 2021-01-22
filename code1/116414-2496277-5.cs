    public static string url2png(string UrlToSite)
    {
        string url2pngAPIKey = "PXXX";
        string url2pngPrivateKey = "SXXX";
    
        string url = HttpUtility.UrlEncode(UrlToSite);
    
        string getstring = "fullpage=true&url=" + url;
    
        string SecurityHash_url2png = Md5HashPHPCompliant(url2pngPrivateKey + "+" + getstring).ToLower();
    
        var url2pngLink = "http://api.url2png.com/v6/" + url2pngAPIKey + "/" + SecurityHash_url2png + "/" + "png/?" + getstring;
    
        return url2pngLink;
    }
    
    public static string Md5HashPHPCompliant(string pass)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
    
        byte[] dataMd5 = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i <= dataMd5.Length - 1; i++)
        {
            sb.AppendFormat("{0:x2}", dataMd5[i]);
        }
    
        return sb.ToString();
    }
