    //used like:
    var data = MyClass.FactoryCreate(() => new Data
    {
        Desc = "something",
        Id = 1
    });
    //Implemented as:
    public static MyClass FactoryCreate(Expression<Func<MyClass>> initializer)
    {
        var myclass = new MyClass();
        ApplyInitializer(myclass, (MemberInitExpression)initializer.Body);
        return myclass ;
    }
    //using this:
    static void ApplyInitializer(object instance, MemberInitExpression initalizer)
    {
        foreach (var bind in initalizer.Bindings.Cast<MemberAssignment>())
        {
            var prop = (PropertyInfo)bind.Member;
            var value = ((ConstantExpression)bind.Expression).Value;
            prop.SetValue(instance, value, null);
        }
    }
