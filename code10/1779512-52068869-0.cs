    [LuisIntent("Help")]
    public async Task HelpIntent(IDialogContext context, LuisResult result)
    {
        var replymes = context.MakeMessage();
    
        var answer = GetAnswer(result.Query);
    
        var cardjson = await GetCardText($"{answer}");
    
        var results = AdaptiveCard.FromJson(cardjson);
        var card = results.Card;
    
        replymes.Attachments.Add(new Attachment()
        {
            Content = card,
            ContentType = AdaptiveCard.ContentType,
            Name = "Card"
        });
    
        await context.PostAsync(replymes);
        context.Wait(MessageReceived);
    }
