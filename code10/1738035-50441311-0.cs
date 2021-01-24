    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
        var activity = await result as Activity;
    
        // calculate something for us to return
        int length = (activity.Text ?? string.Empty).Length;
    
        if (activity.Text.ToLower().Contains("disable upload"))
        {
            var reply = context.MakeMessage() as IEventActivity;
            reply.Type = "event";
            reply.Name = "disablebutton";
            reply.Value = "DisableUploadButton";
            await context.PostAsync((IMessageActivity)reply);
        }
        else if(activity.Text.ToLower().Contains("enable upload"))
        {
            var reply = context.MakeMessage() as IEventActivity;
            reply.Type = "event";
            reply.Name = "enablebutton";
            reply.Value = "EnableUploadButton";
            await context.PostAsync((IMessageActivity)reply);
        }
        else
        {
            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");
        }
    
        context.Wait(MessageReceivedAsync);
    }
