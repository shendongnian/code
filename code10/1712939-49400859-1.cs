    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                //Here we use the Custom Field sent in /Token
                string customer = context.OwinContext.Get<string>("Customer");
    }
 
