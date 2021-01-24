            public static async Task<DialogTurnResult> ProcessInputAsync(
                WaterfallStepContext stepContext,
                CancellationToken cancellationToken)
            {
                var choice = (FoundChoice)stepContext.Result;
                var dialogId = Lists.WelcomeOptions[choice.Index].DialogName;
                return await stepContext.BeginDialogAsync(dialogId, null, cancellationToken);
            }
