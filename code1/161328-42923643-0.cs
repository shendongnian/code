     public static string Getlocalip()
        {
            try
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                return localIPs[7].ToString();
            }
            catch (Exception)
            {
                return "null";
            }
            
        }
