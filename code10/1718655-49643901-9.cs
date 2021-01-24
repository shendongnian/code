    using Microsoft.Bot.Builder.Dialogs;
    using QnAMakerDialog;
    using QnAMakerDialog.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace HalChatBot.Dialogs
    {
        
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
