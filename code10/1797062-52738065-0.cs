    public override void OnSaveSession(
        IRequest httpReq, IAuthSession session, TimeSpan? expiresIn = null)
    {
        base.OnSaveSession(httpReq, session, TimeSpan.FromDays(5));
    }
