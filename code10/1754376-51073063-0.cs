    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var activity = await argument;
        var ts = activity.ChannelData?.SlackMessage?.thread_ts
                 ?? activity.ChannelData?.SlackMessage?.ts
                 ?? activity.ChannelData?.SlackMessage["event"].thread_ts
                 ?? activity.ChannelData?.SlackMessage["event"].ts;
    
        var reply = (Activity)activity;
        reply = reply.CreateReply();
    
        reply.ChannelData = JObject.Parse($"{{text:'reply', thread_ts:'{ts}'}}");
        await context.PostAsync(reply);
    }
