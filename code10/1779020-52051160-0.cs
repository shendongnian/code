    private static AdaptiveCard AvaliarConsultor(List<string> Pergunta)
    {
    
        var adaptiveCard = new AdaptiveCard()
        {
            Body = new List<CardElement>()
            {
                new TextBlock()
                {
                    Text = "Avaliação de questionário 1!",
                    Weight = TextWeight.Bolder,
                    Size = TextSize.Large
                },
                           
    
            },
    
            Actions = new List<ActionBase>()
            {
                new SubmitAction()
                {
                    Title = "Registrar",
                    Speak = "<s>Registrar avaliação</s>",
                    DataJson = "{ \"Type\": \"Registrar\" }"
                }
            }
        };
    
        //dynamically generate TextBlock and ChoiceSet
        //and then add to AdaptiveCard Body
    
        foreach (var item in Pergunta)
        {
            var textblock = new TextBlock() { Text = item };
            var choiceset = new ChoiceSet()
            {
    
                Id = "nota",
                Style = ChoiceInputStyle.Compact,
                IsMultiSelect = false,
                Choices = new List<Choice>()
                        {
                            new Choice()
                            {
                                Title = "⭐",
                                Value = "1"
                            },
    
                            new Choice()
                            {
                                Title = "⭐⭐",
                                Value = "2"
                            },
                            new Choice()
                            {
                                Title = "⭐⭐⭐",
                                Value = "3"
                            },
                            new Choice()
                            {
                                Title = "⭐⭐⭐⭐",
                                Value = "4"
                            },
                            new Choice()
                            {
                                Title = "⭐⭐⭐⭐⭐",
                                Value = "5"
                            }
                        }
            };
    
            adaptiveCard.Body.Add(textblock);
            adaptiveCard.Body.Add(choiceset);
        }
    
        return adaptiveCard;
    }
