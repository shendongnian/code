    namespace NKUtilities 
    {
        using System;
        using System.Net;
        using System.Net.Sockets;
    
        public class DNSUtility
        {
            public static int Main(string [] args)
            {
                string strHostName = "";
                try {
                    if(args.Length == 0)
                    {
                        // Getting Ip address of local machine...
                        // First get the host name of local machine.
                        strHostName = Dns.GetHostName();
                        Console.WriteLine ("Local Machine's Host Name: " +  strHostName);
                    }
                    else
                    {
                        // Otherwise, get the IP address of the host provided on the command line.
                        strHostName = args[0];
                    }
    
                    // Then using host name, get the IP address list..
                    IPHostEntry ipEntry = Dns.GetHostEntry (strHostName);
                    IPAddress [] addr = ipEntry.AddressList;
    
                    for(int i = 0; i < addr.Length; i++)
                    {
                        Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
                    }
                    return 0;
    
                } 
                catch(SocketException se) 
                {
                    Console.WriteLine("{0} ({1})", se.Message, strHostName);
                    return -1;
                } 
                catch(Exception ex) 
                {
                    Console.WriteLine("Error: {0}.", ex.Message);
                    return -1;
                }
            }
        }
    }
