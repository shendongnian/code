    private async Task<DialogTurnResult> PromptForRequestStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        // Save name, if prompted.
        var greetingState = await UserProfileAccessor.GetAsync(stepContext.Context);
        var lowerCaseName = stepContext.Result as string;
        if (string.IsNullOrWhiteSpace(greetingState.Name) && lowerCaseName != null)
        {
            // Capitalize and set name.
            greetingState.Name = char.ToUpper(lowerCaseName[0]) + lowerCaseName.Substring(1);
            await UserProfileAccessor.SetAsync(stepContext.Context, greetingState);
        }     
        if (greetingState.Request == "1")
        {
            var opts = new PromptOptions
            {
                Prompt = MessageFactory.Text("Choose from the following:")
                Choices = new List<Choice>
                {
                    new Choice("Login to OneDrive"),
                    new Choice("Upload a file"),
                    new Choice("Create a folder"),
                },
            };
            return await stepContext.PromptAsync(OneDrivePrompt, opts);
        }
