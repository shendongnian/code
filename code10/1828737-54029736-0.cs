        AddStep(async (stepContext, cancellationToken) => //ERROR
        {
            var nearOrSomewhereElse = stepContext.Result as FoundChoice;
            var state = await (stepContext.Context.TurnState["FPBotAccessors"] as FPBotAccessors).FPBotStateAccessor.GetAsync(stepContext.Context);
            state.NearOrSomewhereElse = nearOrSomewhereElse.Value;
            if (state.NearOrSomewhereElse == "Somewhere else")
            {
                await stepContext.PromptAsync("textPrompt",
                new PromptOptions
                {
                    Prompt = stepContext.Context.Activity.CreateReply("Which location are you considering?")
                });
            }
            else
            {
              await stepContext.NextAsync();
            }
        });
