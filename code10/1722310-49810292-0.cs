    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
    
        string bdate;
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            "{ID_here}",
            "{subscriptionKey_here}", 
            domain: "westus.api.cognitive.microsoft.com")))
        {
        }
        
        //....
        //for other intents
    
        [LuisIntent("GetProjectInfo")]
        public async Task GetProjectInfoIntent(IDialogContext context, LuisResult result) 
        {
    
            if (result.Entities.Count == 0)
            {
                PromptDialog.Text(
                context: context,
                resume: ResumeGetDate,
                prompt: "Please enter the date",
                retry: "Please try again.");
            }
            else
            {
                await this.ShowLuisResult(context, result);
            }
    
                
        }
    
        public async Task ResumeGetDate(IDialogContext context, IAwaitable<string> mes)
        {
            bdate = await mes;
    
            await context.PostAsync($"You reached GetProjectInfo intent. And you entered the date: {bdate}");
    
            context.Wait(MessageReceived);
        }
        
    
        private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");
            context.Wait(MessageReceived);
        }
    }
