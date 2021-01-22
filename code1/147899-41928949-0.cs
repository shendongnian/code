    using System;
    using System.Net.Sockets;
    using DnDns.Enums;
    using DnDns.Query;
    using DnDns.Records;
    namespace DnDnsExamples
    {
    class Program
    {
        static void Main(string[] args)
        {
            DnsQueryRequest request3 = new DnsQueryRequest();
            DnsQueryResponse response3 = request3.Resolve("gmail.com", NsType.MX, NsClass.INET, ProtocolType.Tcp);
            OutputResults(response3);
            Console.ReadLine();
        }
        private static void OutputResults(DnsQueryResponse response)
        {
            foreach (IDnsRecord record in response.Answers)
            {
                Console.WriteLine(record.Answer);
                Console.WriteLine("  |--- RDATA Field Length: " + record.DnsHeader.DataLength);
                Console.WriteLine("  |--- Name: " + record.DnsHeader.Name);
                Console.WriteLine("  |--- NS Class: " + record.DnsHeader.NsClass);
                Console.WriteLine("  |--- NS Type: " + record.DnsHeader.NsType);
                Console.WriteLine("  |--- TTL: " + record.DnsHeader.TimeToLive);
                Console.WriteLine();
            }            
        }
    }
    }
   
