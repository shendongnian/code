    public async Task MessageReceivedWithTextAsync(IDialogContext context, IAwaitable<object> result)
    {
        var activity = await result as Activity;
                
        string r = "";
    
        foreach (var item in dataText)
        {
            if (item.Key == activity.Text)
            {
                r = item.Value;
                break;
            }
        }
    
        var reply = activity.CreateReply(r);
        foreach (var item in dataAtt)
        {
            if (item.Key == activity.Text)
            {
                reply.Attachments.Add(item.Value);
                reply.Text = "attachment";
                break;
            }
        }
    
        if ((string.IsNullOrWhiteSpace(r) || r == null) && reply.Attachments.Count == 0)
        {
            reply.Text = "No tengo respuesta para eso.";
        }
    
                
        // return our reply to the user
        await context.PostAsync(reply);
    }
