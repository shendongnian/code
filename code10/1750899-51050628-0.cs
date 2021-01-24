    var botAccount = new ChannelAccount(name: $"{ConfigurationManager.AppSettings["BotId"]}", id: $"{ConfigurationManager.AppSettings["BotEmail"]}".ToLower()); //botemail is cast to lower so that it can be recognized as valid
                var userAccount = new ChannelAccount(name: "Name", id: $"{ConfigurationManager.AppSettings["UserEmail"]}");//all of these are additional fields within application settings
                MicrosoftAppCredentials.TrustServiceUrl(@"https://email.botframework.com/", DateTime.MaxValue); //a call to TrustServiceUrl is required to send a proactive message to a channel different from the one the user is actively using.
                var connector = new ConnectorClient(new Uri("https://email.botframework.com/" ));
                var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                IMessageActivity message = Activity.CreateMessageActivity();
                message.From = botAccount;
                message.Recipient = userAccount;
                message.Conversation = new ConversationAccount(id: conversationId.Id);
                message.Text = $"Resume recieved from {state.email.ToString()}"; //the actual body of the email
                message.Locale = "en-Us";
                
                message.Attachments = new List<Attachment>();
                message.Attachments.Add(state.file_CV.Attachment);
