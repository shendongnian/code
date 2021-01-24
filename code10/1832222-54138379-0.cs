    var container = new Container();
    container.Register<TargetClass>();
    using (var scope = container.OpenScope("View_1"))
    {
        var instanceA = scope.Resolve<TargetClass>(new[] { typeof(string) });    
    }
    using (var scope = container.OpenScope("View_2"))
    {
        var instanceB = scope.Resolve<TargetClass>(new[] { typeof(int) });
    }
