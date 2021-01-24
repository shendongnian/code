    // Processes ConversationUpdate Activities to welcome the user.
    else if (turnContext.Activity.Type == ActivityTypes.ConversationUpdate)
        {
            if (turnContext.Activity.MembersAdded != null)
            {
                await SendWelcomeMessageAsync(turnContext, cancellationToken);
            }
        }
