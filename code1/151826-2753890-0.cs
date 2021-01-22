    public static string GetUa(HttpRequest hr)
    {
    
        string browser = hr.ServerVariables["X-OperaMini-Phone-UA"];
    
        if (!String.IsNullOrEmpty(browser))
        {
            return "OPERAMINI " + browser;
        }
        else
        {
            browser = hr.ServerVariables["X-Device-User-Agent"]; //novarra 
            if (!String.IsNullOrEmpty(browser))
            {
                return "NOVARRA " + browser;
            }
            else
            {
                if (!String.IsNullOrEmpty(hr.UserAgent))
                    return hr.UserAgent;
            }
        }
        return "No UA Found";
    } 
