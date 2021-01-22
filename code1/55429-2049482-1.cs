    public class NetworkConnectivity
    {
        private List<IPAddress> _ipAddresses = new List<IPAddress>();
        
        public NetworkConnectivity()
        {
            _ipAddresses = new List<IPAddress>();
        }
    
        #region Public Properties
        public int CountIPAddresses
        {
            get { return this.IPAddresses.Count; }
        }
        public List<IPAddress> IPAddresses
        {
            get
            {
                _ipAddresses.Clear();
                // Get a listing of all network adapters
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
                    // If this adapter has at least 1 IPAddress
                    if (addresses.Count > 0)
                    {
                        // Loop through all IP Addresses
                        foreach (GatewayIPAddressInformation address in addresses)
                        {
                            _ipAddresses.Add(address.Address);
                        }
                    }
                } 
                return _ipAddresses;
            }
        }
        public bool IsInternetConnected
        {
            get
            {
                if (this.CountIPAddresses == 0)
                {
                    return false;
                }
                else
                {
                    //IPAddress[] ips = ResolveDNSAddress("google.com");
                    //return PingIPAddressPool(ips);
                    return PingIPAddress("72.14.204.104"); // Google IP
                }
            }
        }
        #endregion
    
        #region Public Methods
        public IPAddress[] ResolveDNSAddress(string UrlAddress)
        {
            IPHostEntry hostInfo = Dns.Resolve(UrlAddress);
            return hostInfo.AddressList;
        }
        public bool PingIPAddressPool(IPAddress[] ipAddresses)
        {
            foreach (IPAddress ip in ipAddresses)
            {
                if (PingIPAddress(ip.Address.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        public bool PingIPAddress(string ip)
        {
            // Pinging
            IPAddress addr = IPAddress.Parse(ip);
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
    
            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;
    
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 15; // seconds to wait for response
            int attempts = 2; // ping attempts
            for (int i = 0; i < attempts; i++)
            {
                PingReply reply = pingSender.Send(addr, timeout, buffer, options); 
                if (reply.Status == IPStatus.Success)
                { return true; }
            }
            return false;
        }
        #endregion
    
    }
