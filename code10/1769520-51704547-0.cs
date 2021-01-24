    else if (message.Type == ActivityTypes.ConversationUpdate)
    {
        // Handle conversation state changes, like members being added and removed
        // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
        // Not available in all channels
    
        if (update.MembersAdded != null && update.MembersAdded.Any())
        {
            foreach (var newMember in update.MembersAdded)
            {
                if (newMember.Name == "{your_botid_here}")
                {
                    IMessageActivity greetingMessage = Activity.CreateMessageActivity();
    
                    //...
                    //your code logic
                    //...
    
                    IMessageActivity dialogEntryMessage = Activity.CreateMessageActivity();
                    dialogEntryMessage.Recipient = message.Recipient;//to bot
                    dialogEntryMessage.From = message.From;//from user
                    dialogEntryMessage.Conversation = message.Conversation;
                    dialogEntryMessage.Text = "show choices";
                    dialogEntryMessage.Locale = "en-us";
                    dialogEntryMessage.ChannelId = message.ChannelId;
                    dialogEntryMessage.ServiceUrl = message.ServiceUrl;
                    dialogEntryMessage.Id = System.Guid.NewGuid().ToString();
                    dialogEntryMessage.ReplyToId = greetingMessage.Id;
    
                    await Conversation.SendAsync(dialogEntryMessage, () => new Dialogs.RootDialog());
                }
            }
        }
    }
