    public override async Task ExecuteAsync(IRequest req, IResponse res, object requestDto)
    {
        if (HostContext.AppHost.HasValidAuthSecret(req))
        {
            return;
        }
        await base.ExecuteAsync(req, res, requestDto);
        if (res.IsClosed)
        {
            return; // AuthenticateAttribute already closed the request (ie auth failed)
        }
        IronUserSession session = req.GetSession() as IronUserSession;
        if (this.HasAnyRoles(req, session))
        {
            return;
        }
        if (this.DoHtmlRedirectIfConfigured(req, res))
        {
            return;
        }
        res.StatusCode = (int) HttpStatusCode.Forbidden;
        res.StatusDescription = ErrorMessages.InvalidRole.Localize(req);
        res.EndRequest();
    }        
