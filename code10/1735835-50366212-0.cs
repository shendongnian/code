     if (member.Type.IsGenericType && member.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
     {
           var isNullCheck = Expression.Equal(member, Expression.Convert(Expression.Constant(null), member.Type));
           return Expression.Or(isNullCheck, Expression.NotEqual(Expression.Property(member, "HasValue"), constant));
     }
     return Expression.NotEqual(Expression.Property(member, "HasValue"), constant);
