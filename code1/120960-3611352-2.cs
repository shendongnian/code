    public bool Evaluate( EvaluationContext evaluationContext, ref object state )
    {
        var identity = ((List<IIdentity>) evaluationContext.Properties[ "Identities" ] ).First();
        if ( identity.AuthenticationType == "MyCustomUserNamePasswordValidator" )
        {
            evaluationContext.Properties[ "Principal" ] = new GenericPrincipal( identity, null );
        }
        else if ( identity.AuthenticationType == "X509" )
        {
            var impersonatedUsername = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>( "ImpersonatedUsername", "http://schemas.mycompany.com/MyProject" );
            evaluationContext.AddClaimSet( this, new DefaultClaimSet( Claim.CreateNameClaim( impersonatedUsername ) ) );
            var impersonatedIdentity = new GenericIdentity( impersonatedUsername, "ImpersonatedUsername" );
            evaluationContext.Properties[ "Identities" ] = new List<IIdentity>() { impersonatedIdentity };
            evaluationContext.Properties[ "Principal" ] = new GenericPrincipal( identity, null );
        }
        else
            throw new Exception( "Bad identity" );
        return true;
    }
