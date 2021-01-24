    await context.PostAsync($"You sent {activity.Text} at {DateTime.Now}");
    
    Task.Delay(5000).ContinueWith(t =>
    {
        using (var scope = Microsoft.Bot.Builder.Dialogs.Internals.DialogModule.BeginLifetimeScope(Conversation.Container, activity))
        {
            var client = scope.Resolve<IConnectorClient>();
            Activity reply = activity.CreateReply($"I can help you with that..");
            client.Conversations.ReplyToActivityAsync(reply);
        }
    });
    
    context.Wait(MessageReceivedAsync);
