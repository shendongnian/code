    GDataGAuthRequestFactory authFactory = new GDataGAuthRequestFactory("lh2", _appName);
    authFactory.AccountType = "GOOGLE_OR_HOSTED";
    
    _picasaService = new PicasaService(authFactory.ApplicationName);
    _picasaService.RequestFactory = authFactory;
