    public static String GetIPAddress()
    {
        String ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
    
        if (string.IsNullOrEmpty(ip))
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        else
            ip = ip.Split(',')[0];
    
        return ip;
    }
