    var settings = new CefSettings();
    settings.RegisterScheme(new CefCustomScheme
    {
        SchemeName = CustomProtocolSchemeHandlerFactory.SchemeName,
        SchemeHandlerFactory = new CustomProtocolSchemeHandlerFactory(),
        IsCSPBypassing = true
    });
    settings.LogSeverity = LogSeverity.Error;
    Cef.Initialize(settings);
