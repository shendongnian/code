    object IClientMessageInspector.BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
    {
        UsernameToken ut = new UsernameToken("USERNAME", "PASSWORD", PasswordOption.SendHashed);
    
        XmlElement securityElement = ut.GetXml(new XmlDocument());
    
        MessageHeader myHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", securityElement, false);
        request.Headers.Add(myHeader);
    
        return Convert.DBNull;
    }
