    [LuisIntent("Gratitude")]
        public async Task Gratitude(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            if (context.UserData.TryGetValue("GratitudeTriggered", out bool gratitudeTriggered))
            {
                //Triggered for the first time, store it in UserData that the Gratitude is triggered
                context.UserData.SetValue("GratitudeTriggered", "yes");
                PromptDialog.Choice
                     (
                      context,
                      ResumeAfterGratitude,
                      new[] { "Yes", "No" },
                      "Thank you. Would you like us to contact you?",
                      promptStyle: PromptStyle.Keyboard, attempts: 4
                    );
            }
            else
                await context.PostAsync("Glad to help");
        }
