    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    
    namespace Bot_Application15.Dialogs
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
    
                foreach (var file in activity.Attachments)
                {
                    //where the file is hosted
                    var remoteFileUrl = file.ContentUrl;
                    //where we are saving the file
                    var localFileName = @"C:\Users\{UserName}\pictures\test" + file.Name;
    
                    using ( var webClient = new WebClient())
                    {
                        webClient.DownloadFile(remoteFileUrl, localFileName);
                    }
                }
                await context.PostAsync($"File received");
    
                context.Wait(MessageReceivedAsync);
            }
        }
    }
