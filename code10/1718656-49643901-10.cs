    [Serializable]
    [QnAMaker("{subscriptionKey_here}", "{knowledgeBaseId_here}")]
    public class BaiscQnaDialog : Microsoft.Bot.Builder.CognitiveServices.QnAMaker.QnAMakerDialog
    {
        protected override async Task RespondFromQnAMakerResultAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
        {
            await context.PostAsync($"I found {result.Answers.Count} answer(s) that might help...{result.Answers.First().Answer}.");
            context.Done(true);
        }
    }
