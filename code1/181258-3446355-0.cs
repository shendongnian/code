        ParameterExpression empParam = Expression.Parameter(typeof(Employee),"emp");
        ConstantExpression equalTarget = Expression.Constant(idToDelete, idToDelete.GetType());
        BinaryExpression intEqualsID = Expression.Equal(
            Expression.PropertyOrField(empParam, targetProperty), equalTarget);
        Expression<Func<Exmployee, bool>> lambda1 =
                    Expression.Lambda<Func<int, bool>>(
                    intEqualsID,
                    empParam);
