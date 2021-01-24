    static public ServiceContext GetServiceContext()
    {
        var accessToken = GetAccessToken(); // Code from above
        var oauthValidator = new OAuth2RequestValidator(accessToken);
        ServiceContext qboContext = new ServiceContext(REALMID_PROD_FROM_STEP10,
                IntuitServicesType.QBO, oauthValidator);
        return qboContext;
    }
