    // Use this for Clients Methods
    public void GetMessage(string message)
        {
            Clients.Caller.acknowledgeMessage($"GetMessage: {message}");
            
        }
