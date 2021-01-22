    using System;
    using System.Net;
    
    class Test
    {
        static void Main(string[] args)
        {
            IPAddress addr = IPAddress.Parse("69.59.196.211");
            IPHostEntry entry = Dns.GetHostEntry(addr);
            Console.WriteLine(entry.HostName); // Prints "stackoverflow.com"
        }
    }
