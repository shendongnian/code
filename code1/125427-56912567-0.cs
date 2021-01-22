    using System.Net.NetworkInformation;
    using System.Linq;
    class Program
    {
         static void Main(string[] args)
         {
            NetworkInterface networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(o => o.OperationalStatus == OperationalStatus.Up && o.NetworkInterfaceType != NetworkInterfaceType.Tunnel && o.NetworkInterfaceType != NetworkInterfaceType.Loopback);
            if (networkInterface != null)
            {
                Console.WriteLine(networkInterface.Name);
            }
         }
    }
