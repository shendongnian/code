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
                    //do something with the file, in this case save it to disk
                    foreach (var file in activity.Attachments)
                    {
                        //where the file is hosted
                        var remoteFileUrl = file.ContentUrl;
    
                        //where we are saving the file
                        var localFileName = @"C:\Users\v-jassow\pictures\test" + file.Name;
    
                        //save the file
                        using (var webClient = new WebClient())
                        {
                            webClient.DownloadFile(remoteFileUrl, localFileName);
                        }
                    }
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
