    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            PromptDialog.Choice(context, ChoiceResumeAfter, (IEnumerable<SupportedProducts>)Enum.GetValues(typeof(SupportedProducts)), "Select a product");
        }
    private async Task ChoiceResumeAfter(IDialogContext context, IAwaitable<SupportedProducts> result)
        {
            var response = await result;
            await context.PostAsync($"You chose {response.ToString()}");
            context.Wait(MessageReceivedAsync);
        }
