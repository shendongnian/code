    ConnectionFactory factory = new ConnectionFactory();
    // "guest"/"guest" by default, limited to localhost connections
    factory.UserName = user;
    factory.Password = pass;
    factory.VirtualHost = vhost;
    factory.HostName = hostName;
    
    IConnection conn = factory.CreateConnection();
