    public static MethodInfo 
        AssertAttributeAppliedToMethod<TExpression, TAttribute>
        (this Expression<T> expression) where TAttribute : Attribute
    {
        // Get the method info in the expression of T.
        MethodInfo mi = (expression.Body as MethodCallExpression).Method;
    
        Assert.That(mi, Has.Attribute(typeof(TAttribute)));
    }
