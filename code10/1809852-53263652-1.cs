    public void ProcessRequest(HttpContext context)
    {
        using (AsyncScopedLifestyle.BeginScope(Bootstrapper.Container))
            Bootstrapper.Container.GetInstance<IsAliveService>().Process(context);
    }
