    private void foo()
    {
        var x = SomeSingleton.Instance.GetX();
        var y = ServiceLocator.GetService<IProvider>().GetY();
    }
