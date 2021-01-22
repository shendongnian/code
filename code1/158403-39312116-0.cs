    using System;
    using System.Net;
    using System.Net.NetworkInformation;
     
    namespace HowToGetLocalDnsServerAddressConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(GetDnsAdress());
                Console.ReadKey();
            }
     
            private static IPAddress GetDnsAdress()
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
     
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if (networkInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                        IPAddressCollection dnsAddresses = ipProperties.DnsAddresses;
     
                        foreach (IPAddress dnsAdress in dnsAddresses)
                        {
                            return dnsAdress;
                        }
                    }
                }
     
                throw new InvalidOperationException("Unable to find DNS Address");
            }
        }
    }
