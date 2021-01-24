    [Serializable]
    public class RootDialog : IDialog<object>
    {
        const string QnAMakerOption = "QnA Maker";
        const string GoogleDriveOption = "Google Drive";
        const string QueryTypeDataKey = "QueryType";
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if(context.UserData.ContainsKey(QueryTypeDataKey))
            {
                var userChoice = context.UserData.GetValue<string>(QueryTypeDataKey);
                if(userChoice == QnAMakerOption)
                    await context.Forward(new QnAMakerDialog(), ResumeAfterQnaMakerSearch, activity);
                else
                    await context.Forward(new GoogleDialog(), ResumeAfterGoogleSearch, activity);
            }
            else
            {
                PromptDialog.Choice(
                      context: context,
                      resume: ChoiceReceivedAsync,
                      options: new[] { QnAMakerOption, GoogleDriveOption },
                      prompt: "Hi. How would you like to perform the search?",
                      retry: "That is not an option. Please try again.",
                      promptStyle: PromptStyle.Auto
                );
            }            
        }
        private Task ResumeAfterGoogleSearch(IDialogContext context, IAwaitable<object> result)
        {
            //do something after the google search dialog finishes
            return Task.CompletedTask;
        }
        private Task ResumeAfterQnaMakerSearch(IDialogContext context, IAwaitable<object> result)
        {
            //do something after the qnamaker dialog finishes
            return Task.CompletedTask;
        }
        private async Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var userChoice = await result;
            context.UserData.SetValue(QueryTypeDataKey, userChoice);
            await context.PostAsync($"Okay, your preferred search is {userChoice}.  What would you like to search for?");
        }
    }
