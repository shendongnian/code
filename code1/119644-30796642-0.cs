        private static List<String> getAllHostNames()
        {
            List<String> hostNames = new List<String>();
            IPAddress[] ipaddress = Dns.GetHostAddresses(Dns.GetHostName());
            String hname;
            foreach (IPAddress ip in ipaddress)
            {
                //if ipv4
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    hname = Dns.GetHostEntry(ip).HostName.ToLower();
                    if (!hostNames.Contains(hname))
                    {
                        hostNames.Add(hname);
                    }
                }
            }
            return hostNames;
        }
