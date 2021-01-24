     Application appObject = new Application { DisplayName = "Test-Demo App" };
     appObject.IdentifierUris.Add("https://localhost/demo/" + Guid.NewGuid());
     appObject.ReplyUrls.Add("https://localhost/demo");
     AppRole appRole = new AppRole
     {
        Id = Guid.NewGuid(),
        IsEnabled = true,
        DisplayName = "Something",
        Description = "Anything",
        Value = "policy.write"
     };
    
     appRole.AllowedMemberTypes.Add("User");
     appObject.AppRoles.Add(appRole);
     activeDirectoryClient.Applications.AddApplicationAsync(appObject).Wait();
     // create a new Service principal
     ServicePrincipal newServicePrincpal = new ServicePrincipal
     {
        DisplayName = appObject.DisplayName,
        AccountEnabled = true,
        AppId = appObject.AppId
     };
    activeDirectoryClient.ServicePrincipals.AddServicePrincipalAsync(newServicePrincpal).Wait();
