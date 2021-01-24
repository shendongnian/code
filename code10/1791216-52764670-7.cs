    bool isValid = false;
    if (authConfig == "AD") {
        using(PrincipalContext pc = new PrincipalContext(ContextType.Domain, "US"))
        {
            // validate the credentials
            isValid = pc.ValidateCredentials(username, password);
        }
    } else if (authConfig == "Custom") {
        isValid = um.IsValid(username, password);
    } 
    // create claim...
