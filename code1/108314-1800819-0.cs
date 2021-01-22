    string name = Dns.GetHostName();
    IPAddress[] addresses = Dns.GetHostAddresses(name);
    foreach (IPAddress address in addresses)
    {
        IPHostEntry entry = Dns.GetHostEntry(address);
        if (String.CompareOrdinal(entry.HostName, address.ToString()) == 0)
        {
            Console.WriteLine(entry.HostName + " is available.");
        }
    }
