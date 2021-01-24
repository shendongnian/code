    public async static Task PostAsyncWithDelay(IDialogContext context, string text)
    {
            await Task.Delay(4000).ContinueWith(t =>
            {
                var message = context.MakeMessage();
                message.Text = text;
                using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                {
                    var client = scope.Resolve<IConnectorClient>();
                    client.Conversations.ReplyToActivityAsync((Activity)message);
                }
    
            });
    }
