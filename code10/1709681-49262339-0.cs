    Component.For<Context>().LifestyleScoped()
    using (container.BeginScope())
    {
        var model = container.Resolve<Model>();
        var initialState = model.GetFirstState();
        var nextState = initialState.GetNextState();
        Assert.That(Context.CreatedCount, Is.EqualTo(0));
    }
    Assert.That(Context.CreatedCount, Is.EqualTo(1));
