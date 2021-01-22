    static Func<object> ArrayCreateInstance(Type type, params int[] bounds) // can be generic too
    {
        var argsExpr = bounds.Select(x => Expression.Constant(x)); // set size
        var newExpr = Expression.NewArrayBounds(type.GetElementType(), argsExpr);
        return Expression.Lambda<Func<object>>(newExpr).Compile();
    }
    // this exercise is pointless if you dont save the compiled delegate, but for demo purpose:
    x = string[] {...
    y = ArrayCreateInstance(x.GetType(), 10)(); // you get 1-d array with size 10
    x = string[,,] {...
    y = ArrayCreateInstance(x.GetType(), 10, 2, 3)(); // you get 3-d array like string[10, 2, 3]
    x = string[][] {...
    y = ArrayCreateInstance(x.GetType(), 10)(); // you get jagged array like string[10][]
