    using System.Net;
    
    string host = Dns.GetHostName();
    IPHostEntry ip = Dns.GetHostEntry(host);
    Console.WriteLine(ip.AddressList[0].ToString());
