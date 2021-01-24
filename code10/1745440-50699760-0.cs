    var reply = context.MakeMessage();
    List<CardAction> enumOptions = new List<CardAction>();
    foreach(ProductGroups option in Enum.GetValues(typeof(ProductGroups)))
    {
        enumOptions.Add(new CardAction
        {
            Title = option.ToString(),
            Type = option.ToString().Equals("MoreCategories") ? ActionTypes.ImBack : ActionTypes.OpenUrl,
            Value = option.GetType()
                    .GetMember(option.ToString())
                    .First()
                    .GetCustomAttribute<DescribeAttribute>()
                    .Description
        });
        
        
    }
    reply.Attachments.Add(GetHeroCard(null, null, null, null, enumOptions));
    await context.PostAsync(reply);
