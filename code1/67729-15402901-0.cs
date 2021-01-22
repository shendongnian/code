    public static IEnumerable<string> GetAddresses()
    {
          var host = Dns.GetHostEntry(Dns.GetHostName());
          return (from ip in host.AddressList where ip.AddressFamily == AddressFamily.lo select ip.ToString()).ToList();
    }
    
