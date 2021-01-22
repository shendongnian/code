    public void DoSomething()
    {
        using (var resourceThatShouldBeDisposed = injectedFactory.CreateResource())
        {
            // do something
        }
    }
