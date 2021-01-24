    private static void Swap<TProperty>(
            Expression<Func<TProperty>> first,
            Expression<Func<TProperty>> second)
    {
        var firstMember = first.Body as MemberExpression;
        var secondMember = second.Body as MemberExpression;
        var variable = Expression.Variable(typeof(TProperty));
        var firstMemberAccess = Expression.MakeMemberAccess(firstMember.Expression, firstMember.Member);
        var secondMemberAccess = Expression.MakeMemberAccess(secondMember.Expression, secondMember.Member);
        var block = Expression.Block(new []{ variable },
            Expression.Assign(variable, firstMemberAccess),
            Expression.Assign(firstMemberAccess, second.Body),
            Expression.Assign(secondMemberAccess, variable)
        );
        Expression.Lambda<Action>(block).Compile()();
    }
