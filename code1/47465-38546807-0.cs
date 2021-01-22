    public static class IPhelper
    {
        public static string GetIPAddress(this HttpRequest Request)
        {
            if (Request.Headers["CF-CONNECTING-IP"] != null) return Request.Headers["CF-CONNECTING-IP"].ToString();
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null) return Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            return Request.UserHostAddress;
        }
    }
