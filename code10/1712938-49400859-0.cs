    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                //Here we get the Custom Field sent in /Token
                string[] customer = context.Parameters.Where(x => x.Key == "customer").Select(x => x.Value).FirstOrDefault();
                if (customer.Length > 0 && customer[0].Trim().Length > 0)
                {
                    context.OwinContext.Set<string>("Customer", customer[0].Trim());
                }
                // Resource owner password credentials does not provide a client ID.
                if (context.ClientId == null)
                {
                    context.Validated();
                }
    
                return Task.FromResult<object>(null);
            }
