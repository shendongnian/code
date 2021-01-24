    public async Task StartAsync(IDialogContext context)
    {
        context.Wait(MessageReceivedAsync);
    }
    
    
    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        var activity = await result as Activity;
    
        var mes = activity.Text?.ToString();
    
        if (mes == "show choices")
        {
            var descriptions = new string[] { "Request a Quote", "More Information About Jobs" };
            PromptDialog.Choice(
                context: context,
                resume: ChoiceReceivedAsync,
                options: descriptions,
                prompt: "Please select an option below:",
                retry: "Selected option not available.",
                promptStyle: PromptStyle.Auto
                );
        }
        else
        {
            if (mes == "More Information About Jobs")
            {
                var replymes = context.MakeMessage();
                replymes.Text = "Click on this link to know more about jobs [https//www.abc.com](https//www.abc.com)";
    
                await context.PostAsync(replymes);
            }
            else if (mes == "Request a Quote")
            {
                //your code logic here
            }
            else
            {
                await context.PostAsync($"You sent {activity.Text}");
            }
    
    
            context.Wait(MessageReceivedAsync);
        }
    }
