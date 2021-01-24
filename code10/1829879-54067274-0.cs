    public GetNameAndAgeDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
    {
        AddStep(async (stepContext, cancellationToken) =>
        {
            return await stepContext.PromptAsync("textPrompt",
                new PromptOptions
                {
                    Prompt = MessageFactory.Text("What's your name?"),
                },
                cancellationToken: cancellationToken);
        });
        AddStep(async (stepContext, cancellationToken) =>
        {
            var name = (string)stepContext.Result;
            stepContext.Values["name"] = name;
            return await stepContext.PromptAsync("numberPrompt",
                new PromptOptions
                {
                    Prompt = MessageFactory.Text($"Hi {name}, How old are you ?"),
                },
                cancellationToken: cancellationToken);
        });
        AddStep(async (stepContext, cancellationToken) =>
        {
            var age = (int)stepContext.Result;
            stepContext.Values["age"] = age;
            return await stepContext.PromptAsync("confirmPrompt",
                new PromptOptions
                {
                    Prompt = MessageFactory.Text($"Got it you're {name}, age {age}.{Environment.NewLine}Is this correct?"),
                },
                cancellationToken: cancellationToken);
        });
        AddStep(async (stepContext, cancellationToken) =>
        {
            var result = (bool)stepContext.Result;
            if(result)
            {
                var state = await (stepContext.Context.TurnState["FPBotAccessors"] as FPBotAccessors).FPBotStateAccessor.GetAsync(stepContext.Context);
                state.Name = stepContext.Values["name"] as string;
                state.Age = stepContext.Values["age"] as int;
                return await stepContext.ReplaceDialogAsync(MainDialog.Id, cancellationToken: cancellationToken);
            }
            else
            {
                //restart the dialog
                return await stepContext.ReplaceDialogAsync(GetNameAndAgeDialog.Id, cancellationToken: cancellationToken);
            }
        });
    }
