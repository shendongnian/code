    if (!username.Contains("@") && !username.Contains(@"\"))
    {
        // EXCEPTION
    }
    var domain = username.Contains("@") ? username.Split("@")[1].Split(".")[0] : username.Split(@"\")[0];
    var principalContext = new PrincipalContext(ContextType.Domain, domain);
    var user = username.Contains("@") ? username.Split("@")[0] : username.Split(@"\")[1];
    var isValid = principalContext.ValidateCredentials(user, cleartextpw);
