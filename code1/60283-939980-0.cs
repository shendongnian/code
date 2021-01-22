    static Delegate MissingFunc(Type result, params Type[] args)
    {
        int i = 0;
        var param = Array.ConvertAll(args,
            arg => Expression.Parameter(arg, "arg" + i++));
        var asObj = Array.ConvertAll(param,
            p => Expression.Convert(p, typeof(object)));
        var argsArray = Expression.NewArrayInit(typeof(object), asObj);
        var body = Expression.Convert(Expression.Call(
                    null, typeof(Program).GetMethod("Resolve"),
                    argsArray), result);
        return Expression.Lambda(body, param).Compile();
    }
    static void Main()
    {
        var func2 = MissingFunc(typeof(string), typeof(int), typeof(float));
    }
    public static object Resolve( params object[] args) {
        throw new NotImplementedException();
    }
