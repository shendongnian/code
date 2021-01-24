    class SomeClass
    {
         public string prop1 { get; set; }
         public string prop2 { get; set; }
    }
    ///...
    private void Update<T, TReturn>(Expression<Func<T, TReturn>> expression) 
    {
        MemberExpression body = (MemberExpression)expression.Body;
        var propName = body.Member.Name;
        var prop = typeof(SomeClass).GetProperty(propName);
        var products = (from p in contextProds
                        where prop.GetValue(p) == null
                        select p);
        ///...
    }
