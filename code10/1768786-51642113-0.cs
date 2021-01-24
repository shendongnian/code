    var container = new Container();
    // Uses the non-ambient scoped lifestyle
    container.Options.DefaultScopedLifestyle = ScopedLifestyle.Flowing;
    container.Register<MyCustomClass>(Lifestyle.Scoped);
    container.Register<MyForm>();
    container.Verify();
    using (var scope = new Scope(container))
    {
        var form = scope.GetInstance<MyForm>();
        form.ShowDialog();
    }
