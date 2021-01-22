    public static string GetUa(HttpRequest hr)
    {
        try
        {
            string visitorBrowser = hr.UserAgent.ToString();
            string originalBrowser = hr.ServerVariables["X-OperaMini-Phone-UA"];
            string anotherOriginalBrowser = hr.ServerVariables["X-Device-User-Agent"]; //novarra
    
            return !(string.IsNullOrEmpty(originalBrowser)) ? "OPERAMINI " + originalBrowser :
                   !(string.IsNullOrEmpty(anotherOriginalBrowser)) ? "NOVARRA " + anotherOriginalBrowser : visitorBrowser);
        }
        catch 
        {
            return "No UA Found";
        }
    }
