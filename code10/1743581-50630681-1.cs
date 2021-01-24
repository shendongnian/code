    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    
    namespace Bot_Application1.Dialogs
    {
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
    
                if (activity.Attachments.Any())
                {
                    //do something with the file
                    //it looks like this is where you would put your 
                    //context.Forward() 
                    await context.Forward(new ReceiveAttachmentDialog(), this.ResumeAfterRecieveDialog, context.Activity, CancellationToken.None);
                    
                    await context.PostAsync($"you sent a file");
                }
                else
                {
                    await context.PostAsync($"No File received");
                }
                context.Wait(MessageReceivedAsync);
            }
        }
    }
