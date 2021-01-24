    else if (context.Activity.Type == ActivityTypes.Event)
    {
        var uparam = context.Activity.From.Properties["userparam"].ToString();
        await context.SendActivity($"Parameter that you sent is '{uparam}'");
    }
