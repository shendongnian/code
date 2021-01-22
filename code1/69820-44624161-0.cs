    public static void SNCT_SendBroadcast(out List<MyDevice> DevicesList)
    {
    DevicesList = new List<MyDevice>();
    byte[] data = new byte[2]; //broadcast data
    data[0] = 0x0A;
    data[1] = 0x60;
    IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 45000); //braodcast IP address, and corresponding port
    NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces(); //get all network interfaces of the computer
    foreach (NetworkInterface adapter in nics)
    {
    // Only select interfaces that are Ethernet type and support IPv4 (important to minimize waiting time)
    if (adapter.NetworkInterfaceType != NetworkInterfaceType.Ethernet) { continue; }
    if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false) { continue; }
    try
    {
        IPInterfaceProperties adapterProperties = adapter.GetIPProperties();    
        foreach (var ua in adapterProperties.UnicastAddresses)
        {
            if (ua.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
             //SEND BROADCAST IN THE ADAPTER
                //1) Set the socket as UDP Client
                Socket bcSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //broadcast socket
                //2) Set socker options
                bcSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                bcSocket.ReceiveTimeout = 200; //receive timout 200ms
                //3) Bind to the current selected adapter
                IPEndPoint myLocalEndPoint = new IPEndPoint(ua.Address, 45000);
                bcSocket.Bind(myLocalEndPoint);
                //4) Send the broadcast data
                bcSocket.SendTo(data, ip);
            //RECEIVE BROADCAST IN THE ADAPTER
                int BUFFER_SIZE_ANSWER = 1024;
                byte[] bufferAnswer = new byte[BUFFER_SIZE_ANSWER];
                do
                {
                    try
                    {
                        bcSocket.Receive(bufferAnswer);
                        DevicesList.Add(GetMyDevice(bufferAnswer)); //Corresponding functions to get the devices information. Depends on the application.
                    }
                    catch { break; }
                } while (bcSocket.ReceiveTimeout != 0); //fixed receive timeout for each adapter that supports our broadcast
                bcSocket.Close();
            }
        }
      }
      catch { }
    }
    return;
    }
