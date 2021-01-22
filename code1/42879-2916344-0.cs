    public static void PrintName(Expression<Func<object>> exp)
    {
    string name = "";
    string val = "";
    MemberExpression body = exp.Body as MemberExpression;
    if (body == null) {
       UnaryExpression ubody = (UnaryExpression)exp.Body;
       body = ubody.Operand as MemberExpression;
       name = body.Member.Name;
    } else {
       name = body.Member.Name;
    }
    }
