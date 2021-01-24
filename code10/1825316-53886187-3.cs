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
            //get the IP Properties for short hand
            IPInterfaceProperties ipProps = adapter.GetIPProperties();
            //set a default value of 0.0.0.0
            IPAddress ipv4 = new IPAddress(0); 
            //if it has one, store the ipv4 of the current adapter
            if(ipProps.UnicastAddresses.Count > 1)
                ipv4 = ipProps.UnicastAddresses[1].Address;
            //set a default value of 0.0.0.0
            IPAddress ipv6 = new IPAddress(0);
            //if it has one, store the ipv6 of the current adapter
            if (ipProps.UnicastAddresses.Count > 0)
                ipv6 = ipProps.UnicastAddresses[0].Address;
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
