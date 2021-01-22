    public static ArrayList getThisCompIPAddress()
        {
            ArrayList strArrIpAdrs = new ArrayList();
            ArrayList srtIPAdrsToReturn = new ArrayList();
            addresslist = Dns.GetHostAddresses(Dns.GetHostName());
            for (int i = 0; i < addresslist.Length; i++)
            {
                try
                {
                    long ip = addresslist[i].Address;
                    strArrIpAdrs.Add(addresslist[i]);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (IPAddress ipad in strArrIpAdrs)
            {
                lastIndexOfDot = ipad.ToString().LastIndexOf('.');
                substring = ipad.ToString().Substring(0, ++lastIndexOfDot);
                if (!(srtIPAdrsToReturn.Contains(substring)) && !(substring.Equals("")))
                {
                    srtIPAdrsToReturn.Add(substring);
                }
            }
            return srtIPAdrsToReturn;
        }
