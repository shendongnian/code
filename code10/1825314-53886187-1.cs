    //create a dictionary storing the name and address of each adapter
    public Dictionary<string,IPAddress> ip4ByAdapter = new Dictionary<string,IPAddress>();
    public Dictionary<string,IPAddress> ip6ByAdapter = new Dictionary<string,IPAddress>();
    void GetIpsAndAdapters()
    {
        //Get the network interfaces
        NetworkInterface[] netInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        
        //don't forget to clear the combo box
        comboBox1.Items.Clear();
        foreach(NetworkInterface adapter in netInterfaces)
        {
            //get the ipv4 and 6 addresses, you can do this any way you like
            IPAddress ipv4= adapter.GetIPProperties().UnicastAddresses[1].Address;
            IPAddress ipv6 = adapter.GetIPProperties().UnicastAddresses[0].Address;
            //store the matching pair of adapter and ip address in dictionary
            //check for duplicates (loopbacks perhaps) and ignore them
            if(!ip4ByAdapter.ContainsKey(adapter.Name))
                ip4ByAdapter.Add(adapter.Name, ipv4);
            
            //same for ipv6
            if(!ip6ByAdapter.ContainsKey(adapter.Name))
                ip6ByAdapter.Add(adapter.Name, ipv6);
            comboBox1.Items.Add(adapter.Name);
        }
    }
