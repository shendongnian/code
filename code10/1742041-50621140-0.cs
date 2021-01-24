    public static async Task StartTyping(IDialogContext context, int sleep)
    {
        var typingMsg = context.MakeMessage();
        typingMsg.Type = ActivityTypes.Typing;
        await context.PostAsync(typingMsg);
        await Task.Delay(sleep);
    }
