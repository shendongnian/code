    private static async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await stepContext.PromptAsync(
        choicePrompt,
        new PromptOptions
        {
            Prompt = MessageFactory.Text($"Here are your choices:"),
            Choices = new List<Choice> { new Choice { Value = "Restart Dialog A" }, new Choice { Value = "Open Dialog B" }, },
            RetryPrompt = MessageFactory.Text($"Please choose one of the options."),
        });
    }
