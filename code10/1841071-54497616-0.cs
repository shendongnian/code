    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string token = null;
        try
        {
            // Give application opportunity to find from a different location, adjust, or reject token
            var messageReceivedContext = new MessageReceivedContext(Context, Scheme, Options);
            // event can set the token
            await Events.MessageReceived(messageReceivedContext);
            if (messageReceivedContext.Result != null)
            {
                return messageReceivedContext.Result;
            }
            // If application retrieved token from somewhere else, use that.
            token = messageReceivedContext.Token;
            if (string.IsNullOrEmpty(token))
            {
                string authorization = Request.Headers["Authorization"];
                ...
