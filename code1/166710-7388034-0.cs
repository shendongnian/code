    // Initialization of the service...
    _service = new MyService("MyEndpoint", RemoteUri);
    // etc.    
    // Calling the service -- note call to GetSecurityHeader()
    _service.ServiceAction(GetSecurityHeader(), "myParam1");
    
    // etc.
    /// <summary>
    /// Construct the WSE 3.0 Security Header
    /// </summary>
    private SecurityHeader GetSecurityHeader()
    {
        SecurityHeader h = new SecurityHeader();
        UsernameToken t = new UsernameToken(RemoteLogin, RemotePassword, PasswordOption.SendPlainText);
        h.Any = new XmlElement[1];
        h.Any[0] = t.GetXml(new XmlDocument());
        return h;
    }
