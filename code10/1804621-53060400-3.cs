        // Greater Than >
            expression = Expression.GreaterThan(Expression.MakeMemberAccess(member, typeof(DateTime).GetMember("Date").Single()), constant);
        // Less Than <
            expression = Expression.LessThan(Expression.MakeMemberAccess(member, typeof(DateTime).GetMember("Date").Single()), constant);
        // Equal
            expression = Expression.Equal(
                       Expression.MakeMemberAccess(member, typeof(DateTime).GetMember("Date").Single()),
                       Expression.Constant(searchValue.Date)
                       );
