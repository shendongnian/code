    //Create a list for the interfaces
    List<EthernetInterface> wpcInterfaces = new List<EthernetInterface>();
    
    //Get all local interfaces
    WinPcapInterface[] arWpc = EthernetInterface.GetAllPcapInterfaces(); 
    
    //Create a router
    Router rRouter = new Router();
    
    //Foreach WinPcapInterface of this host
    foreach (WinPcapInterface wpc in arWpc)
    {
        //Create a new interface handler and start it
        EthernetInterface ipInterface = new EthernetInterface(wpc);
        ipInterface.Start();
    
        //Then add it to the router and to our list
        wpcInterfaces.Add(ipInterface);
        rRouter.AddInterface(ipInterface);
    }
    
    //Create a TCP frame
    TCPFrame tcpFrame = new TCPFrame();
    tcpFrame.DestinationPort = 80;
    tcpFrame.SourcePort = 12345;
    tcpFrame.AcknowledgementFlagSet = true;
    
    //Create an IP frame and put the TCP frame into it
    IPv4Frame ipFrame = new IPv4Frame();
    ipFrame.DestinationAddress = IPAddress.Parse("192.168.0.1");
    ipFrame.SourceAddress = IPAddress.Parse("192.168.1.254");
    
    ipFrame.EncapsulatedFrame = tcpFrame;
    
    //Send the frame
    rRouter.PushTraffic(tcpFrame);
    
    //Cleanup resources
    rRouter.Cleanup();
    
    //Start the cleanup process for all interfaces
    foreach (EthernetInterface ipInterface in wpcInterfaces)
    {
        ipInterface.Cleanup();
    }
    
    //Stop all handlers
    rRouter.Stop();
    
    //Stop all interfaces
    foreach (EthernetInterface ipInterface in wpcInterfaces)
    {
        ipInterface.Stop();
    }
