    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
    {
        if (error is SecurityException)
        {
            var faultEx = new WebFaultException<string>("Forbidden", HttpStatusCode.Forbidden)
            fault = Message.CreateMessage(version, faultEx.CreateMessageFault(), null);
        }
    }
