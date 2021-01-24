       
       // Your first step elided for brevity
       AddStep(async (stepContext, cancellationToken) =>
       {
                var nearOrSomewhereElse = stepContext.Result as FoundChoice;
                var state = await (stepContext.Context.TurnState["FPBotAccessors"] as FPBotAccessors).FPBotStateAccessor.GetAsync(stepContext.Context);
                state.NearOrSomewhereElse = nearOrSomewhereElse.Value;
                if (state.NearOrSomewhereElse == "Near me")
                {
                   value = "Near me";
                }
                else if (state.NearOrSomewhereElse == "Somewhere else")
                {
                   //prompt user. user's answer will be stored to value.
                    value = "User input";
                }
          
                // Call NextAsync passing on the value
                await stepContext.NextAsync(value, cancellationToken);
       });
       AddStep(async (stepContext, cancellationToken) =>
       {
             // Retrieve the result of the previous step
             var x = stepContext.Result as string;
       });
