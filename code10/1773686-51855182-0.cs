    var results = await QnA.GetAnswers(text);
    
    switch (results.Length)
    {
        case 0:
            await context.SendActivity($"I have no topics in the FAQ for '{text}'.");
            await context.SendActivity("Ask me a question.");
            break;
        case 1:
            await context.SendActivity(results[0].Answer);
            break;
    default:
    
            //var options = MessageFactory.SuggestedActions(
            //    results.Select(r => r.Questions[0]).ToList(), "Did you mean:");
            //options.SuggestedActions.Actions.Add(None);
    
            
            //show options using HeroCard
            var options = results.Select(r => r.Questions[0]).ToList();
    
            var herocard = new HeroCard();
            herocard.Text = "Did you mean:";
    
            List<CardAction> buttons = new List<CardAction>();
    
            foreach (var item in options)
            {
                buttons.Add(new CardAction()
                {
                    Type = ActionTypes.ImBack,
                    Title = item.ToString(),
                    Value = item.ToString()
                });
            }
    
            buttons.Add(new CardAction()
            {
                Type = ActionTypes.ImBack,
                Title = "None of the above.",
                Value = "None of the above."
            });
    
            herocard.Buttons = buttons;
    
            var response = context.Activity.CreateReply();
            response.Attachments = new List<Attachment>() { herocard.ToAttachment() };
            await context.SendActivity(response);
            break;
    }
