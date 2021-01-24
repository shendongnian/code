         private async Task<DialogTurnResult> ValidationFirstStepAsync(
                    WaterfallStepContext stepContext,
                    CancellationToken cancellationToken = default(CancellationToken))
                {
                    // Access the bot UserInfo accessor so it can be used to get state info.
                    LanguageAccessor languageAccessor = await 
                    _accessors.LanguageAccessor.GetAsync(stepContext.Context, null, 
                    cancellationToken);
        
                   if ((languageAccessor)stepContext.Context.Activity.Text)
                   {             
                      await stepContext.Context.SendActivityAsync(
                                "Hi!");
                      return await stepContext.NextAsync();
                   }
                   else
                   { 
                      await stepContext.Context.SendActivityAsync("Sorry, your language is not supported");
                      return await stepContext.EndDialogAsync(); }
                   }
    }
