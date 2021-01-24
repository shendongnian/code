     public static async Task<DialogTurnResult> ProcessInputAsync(
                WaterfallStepContext stepContext,
                CancellationToken cancellationToken)
            {
                if ((bool)stepContext.Result)
                {
                    await stepContext.Context.SendActivityAsync(
                        $"Calling {stepContext.Values[Outputs.PhoneNumber]}",
                        cancellationToken: cancellationToken);
                    return await stepContext.EndDialogAsync(null, cancellationToken);
                }
                else
                {
                    return await stepContext.ReplaceDialogAsync(Dialogs.PhonePrompt, null, cancellationToken);
                } 
            }
