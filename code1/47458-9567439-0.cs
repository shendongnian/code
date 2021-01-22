       public string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
            {
               string[] addresses = ipList.Split(',');
               if(addresses.Length > 0)
                   return addresses[0];
            }
            return Request.ServerVariables["REMOTE_ADDR"];   
        }
