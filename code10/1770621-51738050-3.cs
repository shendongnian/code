    // Helpers to make access simpler
    public static class Condition
    {
        // For testing, will fail all variable references
        public static Expression<Func<object, bool>> Parse(string text)
            => ConditionParser<object>.ParseCondition(text);
        public static Expression<Func<T, bool>> Parse<T>(string text)
            => ConditionParser<T>.ParseCondition(text);
        public static Expression<Func<T, bool>> Parse<T>(string text, T instance)
            => ConditionParser<T>.ParseCondition(text);
    }
    public static class ConditionParser<T>
    {
        static ParameterExpression Parm = Expression.Parameter(typeof(T), "_");
        public static Expression<Func<T, bool>> ParseCondition(string text)
            => Lambda.Parse(text);
        static Parser<Expression<Func<T, bool>>> Lambda =>
            OrTerm.End().Select(body => Expression.Lambda<Func<T, bool>>(body, Parm));
        // lowest priority first
        static Parser<Expression> OrTerm =>
            Parse.ChainOperator(OpOr, AndTerm, Expression.MakeBinary);
        static Parser<ExpressionType> OpOr = MakeOperator("or", ExpressionType.OrElse);
        static Parser<Expression> AndTerm =>
            Parse.ChainOperator(OpAnd, NegateTerm, Expression.MakeBinary);
        static Parser<ExpressionType> OpAnd = MakeOperator("and", ExpressionType.AndAlso);
        static Parser<Expression> NegateTerm =>
            NegatedFactor
            .Or(Factor);
        static Parser<Expression> NegatedFactor =>
            from negate in Parse.IgnoreCase("not").Token()
            from expr in Factor
            select Expression.Not(expr);
        static Parser<Expression> Factor =>
            SubExpression
            .Or(BooleanLiteral)
            .Or(BooleanVariable);
        static Parser<Expression> SubExpression =>
            from lparen in Parse.Char('(').Token()
            from expr in OrTerm
            from rparen in Parse.Char(')').Token()
            select expr;
        static Parser<Expression> BooleanValue =>
            BooleanLiteral
            .Or(BooleanVariable);
        static Parser<Expression> BooleanLiteral =>
            Parse.IgnoreCase("true").Or(Parse.IgnoreCase("false"))
            .Text().Token()
            .Select(value => Expression.Constant(bool.Parse(value)));
        static Parser<Expression> BooleanVariable =>
            Parse.Regex(@"[A-Za-z_][A-Za-z_\d]*").Token()
            .Select(name => VariableAccess<bool>(name));
        static Expression VariableAccess<TTarget>(string name)
        {
            MemberInfo mi = typeof(T).GetMember(name, MemberTypes.Field | MemberTypes.Property, BindingFlags.Instance | BindingFlags.Public).FirstOrDefault();
            var targetType = typeof(TTarget);
            var type = 
                (mi is FieldInfo fi) ? fi.FieldType : 
                (mi is PropertyInfo pi) ? pi.PropertyType : 
                throw new ParseException($"Variable '{name}' not found.");
            if (type != targetType)
                throw new ParseException($"Variable '{name}' is type '{type.Name}', expected '{targetType.Name}'");
            return Expression.MakeMemberAccess(Parm, mi);
        }
        // Helper: define an operator parser
        static Parser<ExpressionType> MakeOperator(string token, ExpressionType type)
            => Parse.IgnoreCase(token).Token().Return(type);
    }
