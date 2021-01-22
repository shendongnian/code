    public void BeginSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
    {
       string currentContextUserName = HttpContext.Current.User.Identity.Name;
       MessageHeader userNameHeader = MessageHeader.CreateHeader("Username", "urn:my-custom-namespace", currentContextUserName);
       request.Headers.Add(userNameHeader);
    }
