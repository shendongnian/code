    protected void Session_Start()
    {
        // Starting a session and already authenticated means we have an old cookie
        var existingUser = System.Web.HttpContext.Current.User;
        if (existingUser != null && existingUser.Identity.Name != "")
        {
            IocManager.Instance.UsingScope(scope => // Here
            {
                // Execute app service here.
                var srv = scope.Resolve<SettingsAppService>();
                srv.UpdateItems();
            });
        }
    }
