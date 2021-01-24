    //...
    else if (message.Type == ActivityTypes.ConversationUpdate)
    {
        // Handle conversation state changes, like members being added and removed
        // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
        // Not available in all channels
    
        IConversationUpdateActivity update = message;
        var client = new ConnectorClient(new System.Uri(message.ServiceUrl), new MicrosoftAppCredentials());
        if (update.MembersAdded != null && update.MembersAdded.Any())
        {
            foreach (var newMember in update.MembersAdded)
            {
                if (newMember.Id != message.Recipient.Id)
                {
                    var reply = message.CreateReply();
                    reply.Text = $"Welcome {newMember.Name}! Please enter your number code!";
                    client.Conversations.ReplyToActivityAsync(reply);
                               
                }
            }
        }
    
    }
