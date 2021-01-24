    public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
    {
        session.DisplayName = "MyName";    
        return base.OnAuthenticated(authService, session, tokens, authInfo);
    }
