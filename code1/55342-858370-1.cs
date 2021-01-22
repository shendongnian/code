    using System;
    using System.Net;
    
    public class DNSUtility
    {
        public static int Main (string [] args)
        {
        
          String strHostName = new String ("");
          if (args.Length == 0)
          {
              // Getting Ip address of local machine...
              // First get the host name of local machine.
              strHostName = DNS.GetHostName ();
              Console.WriteLine ("Local Machine's Host Name: " +  strHostName);
          }
          else
          {
              strHostName = args[0];
          }
          
          // Then using host name, get the IP address list..
          IPHostEntry ipEntry = DNS.GetHostByName (strHostName);
          IPAddress [] addr = ipEntry.AddressList;
          
          for (int i = 0; i < addr.Length; i++)
          {
              Console.WriteLine ("IP Address {0}: {1} ", i, addr[i].ToString ());
          }
          return 0;
        }    
     }
