    class Program
    {
        static bool networkIsAvailable = false;
    
        static void Main(string[] args)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
    
            foreach (NetworkInterface nic in nics)
            {
                if (
                    (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback && nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel) &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    networkIsAvailable = true;
                }
            }
    
            Console.Write("Network availability: ");
            Console.WriteLine(networkIsAvailable);
    
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
    
            Console.ReadLine();
        }
    
        static void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            networkIsAvailable = e.IsAvailable;
    
            Console.Write("Network availability: ");
            Console.WriteLine(networkIsAvailable);
        }
    }
