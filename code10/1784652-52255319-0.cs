    card.Body.Add(new AdaptiveTextBlock()
    {
        Text = "Q1:xxxxxxxx?",
        Size = AdaptiveTextSize.Default,
        Weight = AdaptiveTextWeight.Bolder
    });
    
    card.Body.Add(new AdaptiveChoiceSetInput()
    {
        Id = "choiceset1",
        Choices = new List<AdaptiveChoice>()
        {
            new AdaptiveChoice(){
                Title="answer1",
                Value="answer1"
            },
            new AdaptiveChoice(){
                Title="answer2",
                Value="answer2"
            },
            new AdaptiveChoice(){
                Title="answer3",
                Value="answer3"
            }
        },
        Style = AdaptiveChoiceInputStyle.Expanded,
        IsMultiSelect = true
    });
