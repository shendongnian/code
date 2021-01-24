    protected override void OnInitialized()
    {
        try
        {
            // Check if there is an initialization exception
            var page = new AuthenticationPage();
            // Validate that the page resolves ok
            var page2 = Container.Resolve<object>("AuthenticationPage");
            // Validate that your ILogger interface is registered and resolves ok
            var logger = Container.Resolve<ILogger>();
            // Check for Registration/initialization exceptions
            var vm = Container.Resolve<AuthenticationPageViewModel>();
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            System.Diagnostics.Debugger.Break();
        }
    }
