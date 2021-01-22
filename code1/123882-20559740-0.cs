    using NetTools;
    ...
    // rangeA.Begin is "192.168.0.0", and rangeA.End is "192.168.0.255".
    var rangeA = IPAddressRange.Parse("192.168.0.0/255.255.255.0");
    rangeA.Contains(IPAddress.Parse("192.168.0.34")); // is True.
    rangeA.Contains(IPAddress.Parse("192.168.10.1")); // is False.
    rangeA.ToCidrString(); // is 192.168.0.0/24
    
    // rangeB.Begin is "192.168.0.10", and rangeB.End is "192.168.10.20".
    var rangeB1 = IPAddressRange.Parse("192.168.0.10 - 192.168.10.20");
    rangeB1.Contains(IPAddress.Parse("192.168.3.45")); // is True.
    rangeB1.Contains(IPAddress.Parse("192.168.0.9")); // is False.
    
    // Support shortcut range description. 
    // ("192.168.10.10-20" means range of begin:192.168.10.10 to end:192.168.10.20.)
    var rangeB2 = IPAddressRange.Parse("192.168.10.10-20");
    
    // Support CIDR expression and IPv6.
    var rangeC = IPAddressRange.Parse("fe80::/10"); 
    rangeC.Contains(IPAddress.Parse("fe80::d503:4ee:3882:c586%3")); // is True.
    rangeC.Contains(IPAddress.Parse("::1")); // is False.
