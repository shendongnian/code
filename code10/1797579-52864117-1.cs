    public static async Task<DialogTurnResult> ConfirmPhoneAsync(
                WaterfallStepContext stepContext,
                CancellationToken cancellationToken)
            {
                var phoneNumber = stepContext.Context.Activity.Text;
                stepContext.Values[Outputs.PhoneNumber] = phoneNumber;
                return await stepContext.PromptAsync(
                    Inputs.Choice,
                    new PromptOptions
                    {
                        Prompt = MessageFactory.Text($"Is {phoneNumber} your phone number?"),
                        Choices = new List<Choice> { new Choice("yep"), new Choice("nah.") },
                    },
                    cancellationToken);
            }
