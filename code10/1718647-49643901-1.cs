    [Serializable]
    [QnAMakerService("{subscriptionKey_here}", "{ knowledgeBaseId_here}")]
    public class QnADialog : QnAMakerDialog<object>
    {
        public override async Task NoMatchHandler(IDialogContext context, string originalQueryText)
        {
            await context.PostAsync($"Sorry, I couldn't find an answer for '{originalQueryText}'.");
            context.Done(false);
        }
    
        public override async Task DefaultMatchHandler(IDialogContext context, string originalQueryText, QnAMakerResult result)
        {
            await context.PostAsync($"I found {result.Answers.Length} answer(s) that might help...{result.Answers.First().Answer}.");
            context.Done(true);
        }
    }
