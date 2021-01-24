    public static void GetUsers(Expression<Func<UserModel, bool>> predicate)
    {
        var expr = predicate.Body as BinaryExpression;
        var value = expr.Right as ConstantExpression;
        // this will be the value of that predicate Func
        var yourvalue = value.Value;
    }
