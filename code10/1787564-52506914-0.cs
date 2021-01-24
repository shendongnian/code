    [Serializable]
    public class AdaptiveCardsFormFlow
    {
        public string Name { get; set; }
        public DateTime? RequestedDate { get; set; }
    
        public static IForm<AdaptiveCardsFormFlow> BuildForm()
        {
            IFormBuilder<AdaptiveCardsFormFlow> formBuilder = GetFormbuilder();
                
            var built = formBuilder
                .Field(nameof(Name), "What is your name?")
                .Field(nameof(RequestedDate))
                .Confirm("Is this information correct? {*}")
                .Build();
                
            return built;
        }
    
        private static AdaptiveCard GetDateCard()
        {
            AdaptiveCard card = new AdaptiveCard();
            card.Body = new List<AdaptiveElement>()
            {
                new AdaptiveTextBlock()
                {
                    Text = "What date would you like to meet?"
                },
                new AdaptiveDateInput()
                {
                    Value = DateTime.Now.ToShortDateString(),
                    Id = "dateInp"
                },
                new AdaptiveTimeInput()
                {
                    Value = DateTime.Now.ToShortTimeString(),
                    Id = "timeInp"
                }
            };
            card.Actions = new List<AdaptiveAction>()
            {
                new AdaptiveSubmitAction()
                {
                    Type = "Action.Submit",
                    Title = "Confirm"
                }
            };
            return card;
        }
    
        private static IFormBuilder<AdaptiveCardsFormFlow> GetFormbuilder()
        {
    
            IFormBuilder<AdaptiveCardsFormFlow> formBuilder = new FormBuilder<AdaptiveCardsFormFlow>()
                .Prompter(async (context, prompt, state, field) =>
                {
                    var preamble = context.MakeMessage();
                    var promptMessage = context.MakeMessage();
                    if (prompt.GenerateMessages(preamble, promptMessage))
                    {
                        await context.PostAsync(preamble);
                    }
                        
                    if (field != null && field.Name == nameof(AdaptiveCardsFormFlow.RequestedDate))
                    {
                        var attachment = new Attachment()
                        {
                            Content = GetDateCard(),
                            ContentType = AdaptiveCard.ContentType,
                            Name = "Requested Date Adaptive Card"
                        };
    
                        promptMessage.Attachments.Add(attachment);
                    }
    
                    await context.PostAsync(promptMessage);
    
                    return prompt;
                }).Message("Please enter your information to schedule a callback.");
                
            return formBuilder;
        }
    }
