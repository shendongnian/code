    using System;
    using System.Net;
    
    class App
    {
        static long ToInt(string addr)
        {
            // careful of sign extension: convert to uint first;
            // unsigned NetworkToHostOrder ought to be provided.
            return (long) (uint) IPAddress.NetworkToHostOrder(
                 (int) IPAddress.Parse(addr).Address);
        }
        
        static string ToAddr(long address)
        {
            return IPAddress.Parse(address.ToString()).ToString();
            // This also works:
            // return new IPAddress((uint) IPAddress.HostToNetworkOrder(
            //    (int) address)).ToString();
        }
        
        static void Main()
        {
            Console.WriteLine(ToInt("64.233.187.99"));
            Console.WriteLine(ToAddr(1089059683));
        }
    }
