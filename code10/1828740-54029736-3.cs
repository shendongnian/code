            AddStep(async (stepContext, cancellationToken) =>
            {
                var nearOrSomewhereElse = await (stepContext.Context.TurnState["FPBotAccessors"] as FPBotAccessors).FPBotStateAccessor.GetAsync(stepContext.Context).NearOrSomewhereElse;
                // If it's somewhere else, then this step need to get the text value the person was prompted for in the previous step
                if(nearOrSomewhereElse.Value == "Somewhere else")
                {
                   // Get the result of the text prompt from the previous step
                   var whereExactly = stepContext.Result as string;
                   // TODO: store the value in your state so you can reference it later in the final search
                }
                return await stepContext.PromptAsync("choicePrompt",
                 new PromptOptions
                     {
                       Prompt = stepContext.Context.Activity.CreateReply($"Please indicate the size of {state.RealEstateType}"),
                       Choices = new[] {new Choice {Value = "Size 1"},
                                        new Choice {Value = "Size 2"},
                                        new Choice {Value = "Size 3"}
                       }.ToList()
                 });                    
            });
