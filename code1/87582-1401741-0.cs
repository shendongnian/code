    using (PrincipalContext context = new PrincipalContext( ContextType.Domain, "domain" )) {
        if (context.ValidateCredentials( username, password))
        {
            // log them in
        }
        else
        {
           // set up error message and rerender view
        }
    }
