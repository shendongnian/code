    var heroCard = new HeroCard
    {
        Title = "some title",
        Subtitle = "some subtitle",
        Text = "Please select one of the mentioned",
        Buttons = cardObject
    };
    await stepContext.Context.SendActivityAsync(MessageFactory.Attachment(heroCard.ToAttachment()));
    return new DialogTurnResult(DialogTurnStatus.Waiting);
` 
