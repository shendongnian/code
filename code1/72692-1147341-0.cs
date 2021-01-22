    if (context.User.Identity.IsAuthenticated)
    {
        var identity = (HttpListenerBasicIdentity)context.User.Identity;
        Console.WriteLine(identity.Name);
        Console.WriteLine(identity.Password);
    }
