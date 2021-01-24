    if (message.Type == ActivityTypes.ConversationUpdate)
        {
            // Handle conversation state changes, like members being added and removed
            // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
            // Not available in all channels
     
            // Note: Add introduction here:
            IConversationUpdateActivity update = message;
            var client = new ConnectorClient(new Uri(message.ServiceUrl), new MicrosoftAppCredentials());
            if (update.MembersAdded != null && update.MembersAdded.Any())
            {
                foreach (var newMember in update.MembersAdded)
                {
                    if (newMember.Id != message.Recipient.Id)
                    {
                        var reply = message.CreateReply();
                        reply.Text = $"Welcome {newMember.Name}!";
                        client.Conversations.ReplyToActivityAsync(reply);
                    }
                }
            }
        }
