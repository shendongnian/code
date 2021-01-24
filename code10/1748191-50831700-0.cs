    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
            
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
    
            string[] choices = new string[] { "choice 1", "choice 2" };
            PromptDialog.Choice(context, resumeAfterPrompt, choices, "please choose an option.");
        }
    
        private async Task resumeAfterPrompt(IDialogContext context, IAwaitable<string> result)
        {
            string choice = await result;
    
            await context.PostAsync($"You sent {choice}");
            //context.Done<object>(null);
        }
    }
