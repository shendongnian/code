    else if (activity.Type == ActivityTypes.ConversationUpdate)
    {
        // Handle conversation state changes, like members being added and removed
        // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
        // Not available in all channels
    
        IConversationUpdateActivity iConversationUpdated = activity as IConversationUpdateActivity;
        if (iConversationUpdated != null)
        {
            ConnectorClient connector = new ConnectorClient(new System.Uri(activity.ServiceUrl));
            foreach (var member in iConversationUpdated.MembersAdded ?? System.Array.Empty<ChannelAccount>())
            {
                // if the bot is added, then   
                if (member.Id == iConversationUpdated.Recipient.Id)
                {
                    var reply = ((Activity)iConversationUpdated).CreateReply("Hi, Welcome to Systenics.");
                    await connector.Conversations.ReplyToActivityAsync(reply);
    
                    //set value to Text property
                    activity.Text = "show choices";
                    await Conversation.SendAsync(activity, () => new EchoDialog());
                }
            }
        }
    
    }
