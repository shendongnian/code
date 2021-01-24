    static readonly Func<string, Type[], ParameterExpression[], Func<string, Employee>> NewEmployee = (x, y, z) =>
    Expression.Lambda<Func<string, Employee>>(
            Expression.New(Type.GetType(x).GetConstructor(y), z)
    , z).Compile();
    public static Employee InstantiateNewEmployee(string type, string Name)
    {
     Type[] construct = new Type[] { typeof(string) };
     string argumentType = string.Format("{1}.{0}", type.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace);
     ParameterExpression[] arguments = new ParameterExpression[] { Expression.Parameter(typeof(string)) };
     return NewEmployee(argumentType, construct, arguments).Invoke(Name);
    }
