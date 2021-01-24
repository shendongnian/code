    private void OnEvent(...)
    {
        using (var scope = container.BeginLifetimeScope())
        {
            ...
            var myService = scope.Resolve<IMyService>();
            ...
        }
    }
