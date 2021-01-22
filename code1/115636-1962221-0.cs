    using System;
    using System.Net;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ip_range_from = IPAddress.Parse("10.0.0.0");
                Console.WriteLine("From IP {0}, long value {1}", ip_range_from.ToString(), GetLongIP(ip_range_from));            
    
                var ip_range_to = IPAddress.Parse("10.255.255.255");
                Console.WriteLine("To IP {0}, long value {1}", ip_range_to.ToString(), GetLongIP(ip_range_to));
    
                var ip_query_fail = IPAddress.Parse("159.4.1.1");
                Console.WriteLine("ValidIP({0}) returned {1} ",
                    ip_query_fail.ToString(),
                    ValidIP(ip_range_from, ip_range_to, ip_query_fail)
                    );
    
                var ip_query_ok = IPAddress.Parse("10.17.110.12");
                Console.WriteLine("ValidIP({0}) returned {1} ",
                    ip_query_ok.ToString(),
                    ValidIP(ip_range_from, ip_range_to, ip_query_ok)
                    );
    
                Console.Read(); // wait ;)
            }
    
            private static bool ValidIP(IPAddress From, IPAddress To, IPAddress IP)
            {
                long LongIP = GetLongIP(IP);            
                if (LongIP > GetLongIP(From) && LongIP < GetLongIP(To)) return true;
                return false;
            }
    
            private static long GetLongIP(IPAddress IP)
            {
                Byte[] bytes = IP.GetAddressBytes();
                long LongIP = bytes[0] * 0x10000 +
                              bytes[1] * 0x1000 +
                              bytes[2] * 0x100 +
                              bytes[0];
                return LongIP;
            }
        }
    }
