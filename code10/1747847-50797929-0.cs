     public string GetIpAddress()
        {
             var ipAddress=Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
             if(string.IsNullOrEmpty(ipAddress))
             {
                 return Request.ServerVariables["REMOTE_ADDR"];
             }
             return ipAddress;
        }
