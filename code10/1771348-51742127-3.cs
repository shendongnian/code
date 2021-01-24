    SortedUser user = new SortedUser()
    {
        Email = "Foo@bar.com",
        IPAndCountries = new List<IpInfo>()
        {
            new IpInfo() {Ip = "192.168.0.1"},
            new IpInfo() {Ip = "192.168.1.2"},
            new IpInfo() {Ip = "193.168.3.2"},
            new IpInfo() {Ip = "8.2.4.5"}
        }
    };
    // Using ToArray to avoid collection modified errors
    foreach (IpInfo item in user.IPAndCountries.ToArray())
    {
        string[] ipSplit = item.Ip.Split('.');
        string prefix = $"{ipSplit[0]}.{ipSplit[1]}";
        user.IPAndCountries.RemoveAll(info => info.Ip.StartsWith(prefix) && info.Ip != item.Ip);
    }
