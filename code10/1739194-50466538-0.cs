    Expression<Action<Program, object>> e1 = (t, v) => t.Set(v);
    var type = typeof(int);
    var par1 = e1.Parameters[0];
    var par2 = Expression.Parameter(type);
    // if type is a value type, you have to expressly box it 
    Expression conv = type.IsValueType ? (Expression)Expression.Convert(par2, typeof(object)) : par2;
    // We "chain" the two expressions
    InvocationExpression invoke = Expression.Invoke(e1, par1, conv);
    LambdaExpression lambda = Expression.Lambda(invoke, par1, par2);
    var compiled = lambda.Compile();
    // sanity check, 
    bool lambdaTypeIsExpected = typeof(Expression<>).MakeGenericType(typeof(Action<,>).MakeGenericType(typeof(Program), type)) == lambda.GetType();
