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
    
            if (activity.Value != null)
            {
                JToken valueToken = JObject.Parse(activity.Value.ToString());
                string actionValue = valueToken.SelectToken("property") != null ? valueToken.SelectToken("property").ToString() : string.Empty;
    
                var reply = context.MakeMessage();
                string json = "";
    
                switch (actionValue)
                {
                    case "1":
                        json = await GetCardText("card1");
                        break;
                    case "2":
                        json = await GetCardText("card2");
                        break;
                    case "3":
                        json = await GetCardText("card3");
                        break;
                    default:
                        break;
                }
    
                AdaptiveCardParseResult cardParseResult = AdaptiveCard.FromJson(json);
    
                reply.Attachments.Add(new Attachment
                {
                    ContentType = AdaptiveCard.ContentType,
                    Content = cardParseResult.Card
                });
    
                await context.PostAsync(reply);
            }
            else
            {
                if (activity.Text.ToLower().Contains("card"))
                {
                    var replyMessage = context.MakeMessage();
    
                    var json = await GetCardText("maincard");
    
                    AdaptiveCardParseResult cardParseResult = AdaptiveCard.FromJson(json);
    
                    replyMessage.Attachments.Add(new Attachment()
                    {
                        Content = cardParseResult.Card,
                        ContentType = AdaptiveCard.ContentType,
                        Name = "Card"
                    });
    
                    await context.PostAsync(replyMessage);
                }
                else
                {
                    await context.PostAsync($"You sent {activity.Text}");
                }
                    
            }
    
            context.Wait(MessageReceivedAsync);
        }
    
        public async Task<string> GetCardText(string cardName)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath($"/AdaptiveCards/{cardName}.json");
            if (!File.Exists(path))
                return string.Empty;
    
            using (var f = File.OpenText(path))
            {
                return await f.ReadToEndAsync();
            }
        }
    }
