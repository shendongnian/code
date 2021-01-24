     var options = new PromptOptions()
        {
            Prompt = MessageFactory.Text(reservationResult.NewReservation.GetMissingPropertyReadOut()),
        };
        // Start the prompt with the first missing piece of information.
        return await stepContext.PromptAsync(GetLocationDateTimePartySizePrompt, options);
