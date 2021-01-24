    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
    
        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        Accounts acc = new Accounts();
    
        //Authenticate the user credentials
        if (acc.Login(context.UserName, context.Password))
        {   
            //If you want to display user's firstname, lastname, or picture then
            //The below method is for getting user from database by its username
            var user = acc.GetUserByUsername(context.UserName);
            string firstName = user.FirstName;
            string lastName = user.LastName;
    
            identity.AddClaim(new Claim(ClaimTypes.Role, acc.GetUserRole(context.UserName)));
            identity.AddClaim(new Claim("username", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
    
            var props = new AuthenticationProperties(new Dictionary<string, string>
                        {                             
                             {
                                 "userName", context.UserName
                             },
                             {
                                 "firstName", firstName
                             },
                             {
                                 "lastName", lastName
                             }
                        });
    
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }
        else
        {
            context.SetError("invalid_grant", "Provided username and password is incorrect");
            return;
        }
    }
