     private async Task<DialogTurnResult> GreetUser(WaterfallStepContext stepContext)
        {
            var context = stepContext.Context;
            var testState = await TestStateAccessor.GetAsync(context);
            var greetingState = await GreetingStateAccessor.GetAsync(context);
            // Display their profile information and end dialog.
            await context.SendActivityAsync($"Hi {greetingState.Name}, who likes {testState.Animal}s, nice to meet you!");
            return await stepContext.EndDialogAsync();
        }
