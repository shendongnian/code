            try
            {
                var conversationResource = await connectorClient.Conversations.CreateConversationAsync(parameters);
                IMessageActivity message = null;
                if (conversationResource != null)
                {
                    message = Activity.CreateMessageActivity();
                    message.From = new ChannelAccount(botId, botName);
                    message.Conversation = new ConversationAccount(id: conversationResource.Id.ToString());
                    message.Text = Strings.Send1on1Prompt;
                }
                await connectorClient.Conversations.SendToConversationAsync((Activity)message);
            }
            catch (Exception ex)
            {
            }
