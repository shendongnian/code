    protected override void ApplicationStarting(
        UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(
            typeof(DefaultController));
    }
