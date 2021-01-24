        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var userId = activity.From.Id;
            var message = activity.Text;
            if (!Utils.FirstMessageDictionary.ContainsKey(userId))
            {
                 
                Utils.FirstMessageDictionary.Add(userId, message);
                await context.PostAsync($"Message saved {userId} - {Utils.FirstMessageDictionary[userId]}");
            }
            if (message.ToLower() == "no")
            {
                //save to permanent storage here 
                Utils.FirstMessageDictionary.Remove(userId);
                await context.PostAsync($"Entry Removed for {userId}");
                try
                {
                    await context.PostAsync($"{userId} - {Utils.FirstMessageDictionary[userId]}");
                }
                catch (Exception e)
                {
                    await context.PostAsync($"No entry found for {userId}");
                }
            }
            context.Wait(MessageReceivedAsync);
        }
