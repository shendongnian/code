    if (IPV4Interfaces != null)
    {
        List<UnicastIPAddressInformation> RoutableIpAddresses =
            IPV4Interfaces.Where(IF => IF.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                          .Select(IF => IF.GetIPProperties().UnicastAddresses.Last())
                          .Where(UniIP => UniIP.IsDnsEligible).ToList();
    }
