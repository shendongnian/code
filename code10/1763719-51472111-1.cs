    [LuisIntent("Greeting")]
    public async Task GreetingIntent(IDialogContext context, LuisResult result)
    {
    
        var replyMessage = context.MakeMessage();
    
        var json = await GetCardText1("scheduleappointment");
        //await context.PostAsync(json);
        AdaptiveCardParseResult cardParseResult = AdaptiveCard.FromJson(json);
        replyMessage.Attachments.Add(new Attachment()
        {
            Content = cardParseResult.Card,
            ContentType = AdaptiveCard.ContentType,
            Name = "Card"
        });
    
        await context.PostAsync(replyMessage);
    
        //await this.ShowLuisResult(context, result);
    }
    
    public async Task<string> GetCardText1(string cardName)
    {
        var path = System.Web.Hosting.HostingEnvironment.MapPath($"/Dialogs/{cardName}.json");
        if (!File.Exists(path))
            return string.Empty;
    
        using (var f = File.OpenText(path))
        {
            return await f.ReadToEndAsync();
        }
    }
