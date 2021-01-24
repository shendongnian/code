    [Serializable]
    public class RootDialog : IDialog<object>
    {
    bool thenumberisentered = false;
    
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
    
            if (!thenumberisentered)
            {
                string pattern = @"^(?:0|[1-9]\d{0,2})$";
                System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);
    
                if (rgx.IsMatch(activity.Text))
                {
                    //save the number code as user data here 
    
                    thenumberisentered = true;
    
                    await context.PostAsync($"The number code you entered is: {activity.Text}");
                }
                else
                {
                    PromptDialog.Number(context, setUserID, "Please enter your number code", "Error please enter the number again", 2, "", 0, 999);
                    return;
                }
    
            }
            else
            {
                await context.PostAsync($"You sent {activity.Text}");
            }
    
            context.Wait(MessageReceivedAsync);
        }
    
        private async Task setUserID(IDialogContext context, IAwaitable<long> result)
        {
            long numcode = await result;
    
            await context.PostAsync($"The number code you entered is: {numcode}");
    
            thenumberisentered = true;
    
            //save the number code as user data here 
    
            context.Wait(MessageReceivedAsync);
        }
    
    }
