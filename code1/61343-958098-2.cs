    static Expression Like(Expression lhs, Expression rhs)
    {
        return Expression.Call(
            typeof(Program).GetMethod("Like",
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                ,lhs,rhs);
    }
