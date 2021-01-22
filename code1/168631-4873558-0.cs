    // using System.Net.NetworkInformation;
    var nics = NetworkInterface.GetAllNetworkInterfaces();
    // pick your NIC!
    var selectedNic = nics.First();
    
    var macAddress = selectedNic.GetPhysicalAddress().ToString();
