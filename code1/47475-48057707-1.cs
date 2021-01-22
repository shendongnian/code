    public static class RequestExtensions
    {
        public static string GetIPAddress(this HttpRequest Request)
        {
            if (Request.Headers["CF-CONNECTING-IP"] != null) return Request.Headers["CF-CONNECTING-IP"].ToString();
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                    {
                        return addresses[0];
                    }
                }
            }
            return Request.UserHostAddress;
        }
    }
