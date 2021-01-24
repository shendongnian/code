            public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
                    {
                        
                        if (turnContext.Activity.Type == ActivityTypes.Message)
                        {
            // Establish dialog state from the conversation state.
                            DialogContext dc = await _dialogs.CreateContextAsync(turnContext, cancellationToken);
            
                            // Get the user's info.
                           LanguageAccessor languageAccessor = await _accessors.LanguageAccessor.GetAsync(turnContext, () => new LanguageAccessor(), cancellationToken);
            
                            await _accessors.UserInfoAccessor.SetAsync(turnContext, userInfo, cancellationToken);
            
                            // Continue any current dialog.
                            DialogTurnResult dialogTurnResult = await dc.ContinueDialogAsync();    
            
                            // Every dialog step sends a response, so if no response was sent,
                            // then no dialog is currently active and the Else if is entered.
            
                            if (!turnContext.Responded && ((languageAccessor.property)turnContext.Activity.Text))
                            {
                                
                                //This starts the MainDialog if there's no active dialog when the user sends a message
                                await dc.BeginDialogAsync(MainDialogId, null, cancellationToken);
                                
                               
                            }
    
                           //Else if the validation is not passed
                           else if (!turnContext.Responded && ! 
                           ((languageAccessor.property)turnContext.Activity.Text))
                              { await turnContext.SendActivityAsync("Thank you, see you next time"); }
                              }
                }
