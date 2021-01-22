    System.Collections.IDictionary properties = new System.Collections.Hashtable();
    properties["name"] = Ipc_Channel_Name;
    properties["connectiontimeout"] = 1 * 1000;
    
    IChannel clientChannel = new IpcClientChannel(properties, null);
    ChannelServices.RegisterChannel(clientChannel, false);
