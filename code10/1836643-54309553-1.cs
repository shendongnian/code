    private static Expression<Action> CreateExpression<T>(Expression<Func<T>> getLock) where T : IDisposable
    {
        var disposableType = typeof(IDisposable);
        var dispose = disposableType.GetMethod("Dispose");
        if (dispose == null)
            throw new InvalidOperationException();
        var disposable = Expression.Variable(disposableType, "disposable");
        var tryFinally = Expression.TryFinally(
            Expression.Block(
                Expression.Assign(disposable, Expression.Convert(Expression.Invoke(getLock), disposableType))
                // rest of using block
            ),
            Expression.IfThen(
                Expression.NotEqual(disposable, Expression.Constant(null)),
                Expression.Call(disposable, dispose)
            )
        );
        var lambda = Expression.Lambda<Action>(
          Expression.Block(
            new []{disposable}, // variable
            tryFinally // body
          )
        );
        
        return lambda;
    }    
