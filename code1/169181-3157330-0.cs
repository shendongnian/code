    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    // ....
    private static string GetMACAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == OperationalStatus.Up)
                return AddressBytesToString(nic.GetPhysicalAddress().GetAddressBytes());
        }
        return string.Empty;
    }
    private static string AddressBytesToString(byte[] addressBytes)
    {
        return string.Join(":", (from b in addressBytes
                                 select b.ToString("X2")).ToArray());
    }
