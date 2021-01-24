    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
        var activity = await result as Activity;
    
        // calculate something for us to return
        int length = (activity.Text ?? string.Empty).Length;
    
        var varName = "";
    
        if (activity.Text.ToLower().Contains("hello"))
        {
            context.ConversationData.SetValue<string>("varName", activity.Text);
        }
    
        if (activity.Text.ToLower().Contains("getval"))
        {
            varName = context.ConversationData.GetValueOrDefault<string>("varName", "");
    
            activity.Text = $"{varName} form cosmos";
        }
    
        if (activity.Text.ToLower().Contains("remove"))
        {
            activity.Text = "varName is removed";
        }
    
        // return our reply to the user
        await context.PostAsync($"{activity.Text}");
    
        context.Wait(MessageReceivedAsync);
    }
