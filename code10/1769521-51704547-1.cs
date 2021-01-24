    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
        var activity = await result as Activity;
    
        var mes = activity.Text.ToLower();
    
        string[] choices = new string[] { "choice 1", "choice 2" };
    
        if (Array.IndexOf(choices, mes) > -1)
        {
            await context.PostAsync($"You selected {mes}");
        }
        else if(mes == "show choices")
        {
            PromptDialog.Choice(context, resumeAfterPrompt, choices, "please choose an option.");
        }
        else
        {
            await context.PostAsync($"You sent {activity.Text} which was {length} characters.");
            context.Wait(MessageReceivedAsync);
        }
    
    }
    
    private async Task resumeAfterPrompt(IDialogContext context, IAwaitable<string> result)
    {
        string choice = await result;
    
        await context.PostAsync($"You selected {choice}");
    }
