           if (activity.Type == ActivityTypes.Message)
            {
                var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity isTypingReply = activity.CreateReply();
                isTypingReply.Type = ActivityTypes.Typing;
                await connector.Conversations.ReplyToActivityAsync(isTypingReply);
                var message = isTypingReply;
                await Task.Delay(4000).ContinueWith(t =>
                {
                    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                    {
                    }
                });
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
