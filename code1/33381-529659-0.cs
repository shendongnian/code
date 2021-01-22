    bool IAuthorizationPolicy.Evaluate(
        EvaluationContext evaluationContext, ref object state)
    {           
        IList<IIdentity> idents;
        object identsObject;
        if (evaluationContext.Properties.TryGetValue(
            "Identities", out identsObject) && (idents =
            identsObject as IList<IIdentity>) != null)
        {
            foreach (IIdentity ident in idents)
            {
                if (ident.IsAuthenticated &&
                    ident.AuthenticationType == TrustedAuthType)
                {                           
                    evaluationContext.Properties["Principal"]
                        = //TODO our principal
                    return true;
                }
            }
        }
        if (!evaluationContext.Properties.ContainsKey("Principal"))
        {
            evaluationContext.Properties["Principal"] = //TODO anon
        }                
        return false;
    }
