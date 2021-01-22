    var x = Expression.Parameter(typeof(object), "x");
    var y = Expression.Parameter(typeof(object), "y");
    var binder = Binder.BinaryOperation(
        CSharpBinderFlags.None, ExpressionType.Add, typeof(Program),
        new CSharpArgumentInfo[] { 
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), 
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)});
    Func<dynamic, dynamic, dynamic> f =
        Expression.Lambda<Func<object, object, object>>(
            Expression.Dynamic(binder, typeof(object), x, y),
            new[] { x, y }
        ).Compile();
