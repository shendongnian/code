    protected override void RegisterTypes(IContainerRegistry cr)
    {
        cr.Register<ILogger, LoggerConsole>();
        cr.GetContainer().RegisterMany(new[] { Assembly.Load("Project.UWP") },
                       serviceTypeCondition: type => type == typeof(ILocalFileHandler));
        cr.Register<INegotiator, Negotiator>();
        cr.RegisterForNavigation<NavigationPage>();
        cr.RegisterForNavigation<MainPage>();
        cr.RegisterForNavigation<AuthenticatePage>();
    }
