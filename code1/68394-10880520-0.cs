    class Program
    {
        static void Main(string[] args)
        {
            String strHostName = string.Empty;
            if (args.Length == 0)
            {                
                /* First get the host name of local machine.*/
                strHostName = Dns.GetHostName();
                Console.WriteLine("Local Machine's Host Name: " + strHostName);
            }
            else
            {
                strHostName = args[0];
            }
            /* Then using host name, get the IP address list..*/
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            for (int i = 0; i < addr.Length; i++)
            {
                Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
            }
            Console.ReadLine();
        }
    }
}
