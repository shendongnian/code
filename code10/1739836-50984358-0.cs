        private async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            if (message.Attachments != null && message.Attachments.Any())
            {
                // Do something with the attachment
            }
            else
            {
                await context.PostAsync("Please upload a picture");
                context.Wait(this.MessageReceived);
            }
        }
