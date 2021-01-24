	public override async Task ExecuteAsync(IRequest req, IResponse res, object requestDto)
	{
		if (AuthenticateService.AuthProviders == null)
			throw new InvalidOperationException(
				"The AuthService must be initialized by calling AuthService.Init to use an authenticate attribute");
		if (HostContext.HasValidAuthSecret(req))
			return;
		var authProviders = AuthenticateService.GetAuthProviders(this.Provider);
		if (authProviders.Length == 0)
		{
			await res.WriteError(req, requestDto, $"No registered Auth Providers found matching {this.Provider ?? "any"} provider");
			res.EndRequest();
			return;
		}
		
		req.PopulateFromRequestIfHasSessionId(requestDto);
		PreAuthenticate(req, authProviders);
		if (res.IsClosed)
			return;
		var session = req.GetSession();
		if (session == null || !authProviders.Any(x => session.IsAuthorized(x.Provider)))
		{
			if (this.DoHtmlRedirectIfConfigured(req, res, true))
				return;
			await AuthProvider.HandleFailedAuth(authProviders[0], session, req, res);
		}
	}
