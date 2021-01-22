    using System.Net.NetworkInformation;
    
    public bool IsNetworkLikelyAvailable() {
      return NetworkInterface
        .GetAllNetworkInterfaces()
        .Any(x => x.OperationalStatus == OperationalStatus.Up);
    }
