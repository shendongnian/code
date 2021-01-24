    else if (turnContext.Activity.Type == ActivityTypes.Event)
    {
          await turnContext.SendActivityAsync($"Received event");
          await turnContext.SendActivityAsync($"{turnContext.Activity.Name} - {turnContext.Activity.Value?.ToString()}");
    }
