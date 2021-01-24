        private async Task<DialogTurnResult> DisplayCardAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var adaptiveCardJson = File.ReadAllText(Path.Combine(".", "AdaptiveCard.json"));
            var cardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            var cardReply = stepContext.Context.Activity.CreateReply();
            cardReply.Attachments = new List<Attachment>() { cardAttachment };
            // Display the Adaptive Card
            await stepContext.Context.SendActivityAsync(cardReply);
            var opts = new PromptOptions
            {
                Prompt = new Activity
                {
                    Type = ActivityTypes.Message,
                    Text = "waiting for user input...",
                }
            };
            // Display a Text Prompt and wait for input
            return await stepContext.PromptAsync(TextPrompt, opts);
        }
        private async Task<DialogTurnResult> HandleResponseAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            // Do something with step.result
            // Adaptive Card submissions are objects, so you likely need to JObject.Parse(step.result)
            await stepContext.Context.SendActivityAsync($"INPUT: {stepContext.Result}");
            return await stepContext.NextAsync();
        }
