    private bool Authenticate()
    {
         using (var context = new PrincipalContext(ContextType.Domain, Environment.UserDomainName)) 
         {
             return context.ValidateCredentials(this.Username.Text, this.Password.Text, ContextOptions.Negotiate);
         }
    }
