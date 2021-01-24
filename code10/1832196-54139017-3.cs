    // using Abp.Configuration.Startup;
    public override void PreInitialize()
    {
        Configuration.ReplaceService<IAuthorizationHelper, NonUserAuthorizationHelper>();
    }
