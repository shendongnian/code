    // Using SimpleExpressionReplacer from https://stackoverflow.com/a/29467969/613130
    public static Expression<Func<BaseClass, bool>> Filter<TDerived>(Expression<Func<TDerived, bool>> test)
        where TDerived : BaseClass
    {
        // x => 
        var par = Expression.Parameter(typeof(BaseClass), "x");
        // x is TDerived
        var istest = Expression.TypeIs(par, typeof(TDerived));
        // (TDerived)x
        var convert = Expression.Convert(par, typeof(TDerived));
        // If test is p => p.something == xxx, replace all the p with ((TDerived)x)
        var test2 = new SimpleExpressionReplacer(test.Parameters[0], convert).Visit(test.Body);
        // x is TDerived && test (modified to ((TDerived)x) instead of p)
        var and = Expression.AndAlso(istest, test2);
        // x => x is TDerived && test (modified to ((TDerived)x) instead of p)
        var test3 = Expression.Lambda<Func<BaseClass, bool>>(and, par);
        return test3;
    }
