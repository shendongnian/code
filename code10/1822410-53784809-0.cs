    public async Task<DialogTurnResult> AskForLocation(WaterfallStepContext sc, CancellationToken cancellationToken)
        {
            // the previous step asked for the Email so now bot is going to save it in botstate
            _state = await _accessor.GetAsync(sc.Context, () => new MyApplicationState());
            var email = _state.Email = (string)sc.Result;
            // this is not in the template because it is saving in a different manner
            // just being explicit about saving here
            await _accessor.SetAsync(sc.Context, _state);
            await sc.Context.SendActivityAsync("Got your email!");
            var prompt = new PromptOptions
            {
                    Prompt = MessageFactory.Text($"Please specify location."),
            };
            return await stepContext.PromptAsync(locationPrompt, prompt);
        }
        public async Task<DialogTurnResult> FinishDialog(WaterfallStepContext sc, CancellationToken cancellationToken)
        {
            _state = await _accessor.GetAsync(sc.Context);
            _state.Location = (string)sc.Result;
            
            // save location this time
            await _accessor.SetAsync(sc.Context, _state);
            await sc.Context.SendActivityAsync("Got your location!");
            return await sc.EndDialogAsync();
        }
