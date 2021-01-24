    else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
                {
                    var reply = message.CreateReply();
                    var card = new HeroCard();
                    // Make your HeroCard as you wish
                    reply.Attachments.Add(card.ToAttachment());
                    ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
            }
