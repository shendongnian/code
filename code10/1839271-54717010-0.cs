    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        
        if (turnContext.Activity.Type == ActivityTypes.Message)
        {   
            // Check if user submitted AdaptiveCard input
            if (turnContext.Activity.Value != null) {
                // Convert String to JObject
                String value = turnContext.Activity.Value.ToString();
                JObject results = JObject.Parse(value);
                // Get type from input field
                String name = results.GetValue("Type").ToString();
                // Get Keywords from input field
                String userInputKeywords = "";
                if (name == "GetPPT") {
                        userInputKeywords = results.GetValue("GetUserInputKeywords").ToString();
                }
                // Make Http request to api with paramaters
                String myUrl = $"http://myurl.com/api/{userInputKeywords}";
                ...
                // Respond to user
                await turnContext.SendActivityAsync("Respond to user", cancellationToken: cancellationToken);
            } else {
                // Send user AdaptiveCard
                var cardAttachment = GetUserInputForCustomPPT();
                var reply = turnContext.Activity.CreateReply();
                reply.Attachments = new List<Attachment>() { cardAttachment };
                await turnContext.SendActivityAsync(reply, cancellationToken);
            }
        }
    }
