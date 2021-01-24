    [Serializable]
    [QnAMakerService("https://xxxx.azurewebsites.net/qnamaker/", "{EndpointKey_here}", "{KnowledgeBaseId_here}",1)]
    public class MyQnADialog : QnAMakerDialog<object>
    {
        public override async Task NoMatchHandler(IDialogContext context, string originalQueryText)
        {
            await context.PostAsync($"Sorry, I couldn't find an answer for '{originalQueryText}'.");
            context.Done(false);
        }
    
        public override async Task DefaultMatchHandler(IDialogContext context, string originalQueryText, QnAMakerResult result)
        {
            if (result.Answers.FirstOrDefault().Score > 80)
            {
                await context.PostAsync($"I found {result.Answers.Length} answer(s) that might help...{result.Answers.First().Answer}.");
            }
            else
            {
                await context.PostAsync($"Sorry, I couldn't find an answer for '{originalQueryText}'.");
            }
                
            context.Done(true);
        }
    }
