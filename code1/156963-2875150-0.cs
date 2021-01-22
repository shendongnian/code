    public AccountService()
    {
        _accountRepository = ObjectFactory.GetInstance<IAccountRepository>();
        _permissionRepository = ObjectFactory.GetInstance<IPermissionRepository>();
        _userSession = ObjectFactory.GetInstance<IUserSession>();
        _redirector = ObjectFactory.GetInstance<IRedirector>();
        _email = ObjectFactory.GetInstance<IEmail>();
        _profileService = ObjectFactory.GetInstance<IProfileService>();
        _webContext = ObjectFactory.GetInstance<IWebContext>();
        _friendService = ObjectFactory.GetInstance<IFriendService>();
    }
