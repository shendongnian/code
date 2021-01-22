    public string GetIP(bool CheckForward = false)
    {
        string ip = null;
        if (CheckForward) {
            ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
    
        if (string.IsNullOrEmpty(ip)) {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        } else { // Using X-Forwarded-For last address
            ip = ip.Split(',')
                   .Last()
                   .Trim();
        }
    
        return ip;
    }
