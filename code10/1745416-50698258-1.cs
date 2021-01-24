    //Extract the Dns Eligible IP addresses
    if (IPV4Interfaces != null)
    {
        List<UnicastIPAddressInformation> RoutableIpAddresses =
            IPV4Interfaces.Select(IF => IF.GetIPProperties().UnicastAddresses.Last())
                          .Where(UniIP => UniIP.IsDnsEligible).ToList();
    }
