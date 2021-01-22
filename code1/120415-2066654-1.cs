    private static void SomeMethod(int thisValue, string thatValue)  
    { 
        IEnumerable<object> parameters = GetParameters(() => SomeMethod(thisValue, thatValue)); 
        foreach (var p in parameters) 
            Console.WriteLine(p); 
    }
    private static IEnumerable<object> GetParameters(Expression<Action> expr)
    {
        var body = (MethodCallExpression)expr.Body;
        foreach (MemberExpression a in body.Arguments)
        {
            var test = ((FieldInfo)a.Member).GetValue(((ConstantExpression)a.Expression).Value);
            yield return test;
        }
    }
