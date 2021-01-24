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
            var activity = await result as Activity;
    
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
    
            var contractnumber = "";
    
            if (!context.UserData.TryGetValue<string>("contract_number", out contractnumber))
            {
                //prompt for contract number
                PromptDialog.Text(
                context: context,
                resume: AfterGetContractNumber,
                prompt: "Please provide your contract number.",
                retry: "Please try again."
            );
            }
            else
            {
                await context.Forward(new BaiscLuisDialog(), AfterLuisDialog, context.Activity, CancellationToken.None);
    
            }
        }
    
        private async Task AfterGetContractNumber(IDialogContext context, IAwaitable<string> result)
        {
            string contractnumber = await result;
    
            context.UserData.SetValue<string>("contract_number", contractnumber);
    
            await context.PostAsync($"OK, received your contract number: {contractnumber}.");
    
            context.Done(this);
        }
    
    
        private async Task AfterLuisDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceivedAsync);
        }
    }
