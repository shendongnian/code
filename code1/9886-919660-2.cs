    // initialize FTP client 
    Ftp client = new Ftp();
    
    // setup proxy details  
    client.Proxy.ProxyType = FtpProxyType.HttpConnect;
    client.Proxy.Host = proxyHostname;
    client.Proxy.Port = proxyPort;
    
    // add proxy username and password when needed 
    client.Proxy.UserName = proxyUsername;
    client.Proxy.Password = proxyPassword;
    
    // connect, login 
    client.Connect(hostname, port);
    client.Login(username, password);
    
    // do some work 
    // ... 
    
    // disconnect 
    client.Disconnect();
