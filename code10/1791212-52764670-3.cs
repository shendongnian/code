    if (authConfig == "AD") {
        using(PrincipalContext pc = new PrincipalContext(ContextType.Domain, "US"))
        {
            // validate the credentials
            bool isValid = pc.ValidateCredentials(username, password);
        }
    } else if (authConfig == "Custom") {
        um.IsValid(username, password);
    } 
    // continue...
