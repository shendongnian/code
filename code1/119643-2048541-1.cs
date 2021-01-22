    public static int GetAllIPAndHostNames()
            {
                string strHostName;
    
                // Getting Ip address of local machine...
                // First get the host name of local machine.
                strHostName = Dns.GetHostName();
                Console.WriteLine("Local Machine's Host Name: " + strHostName);
                
                IPHostEntry remoteIP;
    
                //using host name, get the IP address list..
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] addr = ipEntry.AddressList;
    
                int i = 0;
                while (i < addr.Length)
                {
                    Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
                    //HostNames
                    remoteIP = Dns.GetHostEntry((addr[i]));
                    Console.WriteLine("HostName {0}: {1} ", i, remoteIP.HostName);
                    i++;
                }
                return 0;
            }
