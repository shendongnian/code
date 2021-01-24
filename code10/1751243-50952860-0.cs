    services.AddAuthentication().AddOAuth("LinkedIn", "LinkedIn", c => {
        // ...
        c.Events.OnRemoteFailure = ctx =>
        {
            // React to the error here. See the notes below.
            return Task.CompletedTask;
        }
        // ...
    });
