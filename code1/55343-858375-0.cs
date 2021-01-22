    using System;
    using System.Net;
    
    
    namespace ConsoleTest
    {
        class Program
        {
            static void Main()
            {
                String strHostName = string.Empty;
                // Getting Ip address of local machine...
                // First get the host name of local machine.
                strHostName = Dns.GetHostName();
                Console.WriteLine("Local Machine's Host Name: " + strHostName);
                // Then using host name, get the IP address list..
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] addr = ipEntry.AddressList;
    
                for (int i = 0; i < addr.Length; i++)
                {
                    Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
                }
                Console.ReadLine();
            }
        }
    }
