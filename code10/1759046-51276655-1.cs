    protected override async Task DefaultWaitNextMessageAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
    {
        if (message.Text.Equals("None of the above."))
        {
            // your code logic
    
            await context.PostAsync("You selected 'None of the above.'");
        }
    
        await base.DefaultWaitNextMessageAsync(context, message, result);
    }
