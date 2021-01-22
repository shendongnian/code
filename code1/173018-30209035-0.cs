    public string GetClientIp() {
        var ipAddress = string.Empty;
        if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null) {
            ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        } else if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null &&
                   System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0) {
            ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
        } else if (System.Web.HttpContext.Current.Request.UserHostAddress.Length != 0) {
            ipAddress = System.Web.HttpContext.Current.Request.UserHostName;
        }
        return ipAddress;
    } 
