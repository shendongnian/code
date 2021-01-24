    public Attachment create_button()
        {
    
            var card = new HeroCard("Some Text");
            card.Buttons = new List<CardAction>()
            {
                new CardAction()
                {
                    Title = "button1",
                    Type=ActionTypes.ImBack,
                    Value="button1"
                },
                new CardAction()
                {
                    Title = "button2",
                    Type=ActionTypes.PostBack,
                    Value="button2"
                }
            };
    
            Attachment cardAttachment = card.ToAttachment();
            return cardAttachment;
        }
