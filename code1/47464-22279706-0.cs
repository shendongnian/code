    public string getIP(HttpContext c)
    {
        string ips = c.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ips))
        {
            return ips.Split(',')[0];
        }
        return c.Request.ServerVariables["REMOTE_ADDR"];
    }
