            Expression<Func<T, bool>> GetDetailEx<T>(string fieldName, object comparisonValue, string filterType)
        {
            var e = Expression.Parameter(typeof(T),"e");
            switch (GetFilterOperationType(filterType))
            {
                case FilterOperationTypes.Between:
                    //Between is automatically translated in >= AND <= within the ExecuteDeepFilter-Method
                    break;
                case FilterOperationTypes.GreaterThanOrEquals:
                    {
                        return GenerateConditionalExpression<T>(fieldName, comparisonValue, Expression.GreaterThanOrEqual(
                                Expression.Convert(Expression.Property(e, fieldName), Expression.Constant(comparisonValue).Type),
                                Expression.Constant(comparisonValue)),e);
                    }
                case FilterOperationTypes.LessThanOrEquals:
                    {
                        return GenerateConditionalExpression<T>(fieldName, comparisonValue, Expression.LessThanOrEqual(
                            Expression.Convert(Expression.Property(e, fieldName), Expression.Constant(comparisonValue).Type),
                            Expression.Constant(comparisonValue)),e);
                    }
                case FilterOperationTypes.GreaterThan:
                    {
                        return GenerateConditionalExpression<T>(fieldName, comparisonValue, Expression.GreaterThan(
                            Expression.Convert(Expression.Property(e, fieldName), Expression.Constant(comparisonValue).Type),
                            Expression.Constant(comparisonValue)), e);
                    }
                case FilterOperationTypes.LessThan:
                    {
                        return GenerateConditionalExpression<T>(fieldName, comparisonValue, Expression.LessThan(
                            Expression.Convert(Expression.Property(e, fieldName), Expression.Constant(comparisonValue).Type),
                            Expression.Constant(comparisonValue)), e);
                    }
                case FilterOperationTypes.NotEqual:
                    {
                        return GenerateConditionalExpression<T>(fieldName, comparisonValue, Expression.NotEqual(
                            Expression.Convert(Expression.Property(e, fieldName), Expression.Constant(comparisonValue).Type),
                            Expression.Constant(comparisonValue)), e);
                    }
                case FilterOperationTypes.Equal:
                    {
                        return GenerateConditionalExpression<T>(fieldName, comparisonValue, Expression.Equal(
                            Expression.Convert(Expression.Property(e, fieldName), Expression.Constant(comparisonValue).Type),
                            Expression.Constant(comparisonValue)), e);         
                    }
                case FilterOperationTypes.EndsWith:
                    {
                        return GenerateGenericCallExpression<T>(fieldName, comparisonValue, "EndsWith",e);
                    }
                case FilterOperationTypes.StartsWith:
                    {
                        return GenerateGenericCallExpression<T>(fieldName, comparisonValue, "StartsWith",e);
                    }
                case FilterOperationTypes.NotContains:
                    {
                        return GenerateGenericCallExpression<T>(fieldName, comparisonValue, "Contains",e,false); ;
                    }
                case FilterOperationTypes.Contains:
                    {
                        return GenerateGenericCallExpression<T>(fieldName, comparisonValue, "Contains",e);
                    }
                default:
                    break;
            }
            return GenerateConditionalExpression<T>(fieldName, comparisonValue, Expression.Equal(
                Expression.Convert(Expression.Property(e, fieldName), Expression.Constant(comparisonValue).Type),
                Expression.Constant(comparisonValue)), e);
        }
        private Expression<Func<T, bool>> GenerateConditionalExpression<T>(string fieldName, object comparisonValue, Expression actualExpression, ParameterExpression e)
        {
            Expression call = Expression.Condition(Expression.Equal(e, Expression.Constant(null)),
            Expression.NotEqual(e, Expression.Constant(null)),
            Expression.Condition(Expression.Equal(Expression.Property(e, fieldName), Expression.Constant(null)),
            Expression.NotEqual(e, Expression.Constant(null)), actualExpression));
            return Expression.Lambda<Func<T, bool>>(call, e);
        }
        private Expression<Func<T, bool>> GenerateGenericCallExpression<T>(string fieldName, object comparisonValue, string methodName, ParameterExpression e, bool equals = true)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(fieldName);
            MemberExpression m = Expression.MakeMemberAccess(e, propertyInfo);
            ConstantExpression c = Expression.Constant(comparisonValue, typeof(string));            
            MethodInfo mi = typeof(string).GetMethod(methodName, new Type[] { typeof(string) });
            if (equals)
            {
                Expression call = Expression.Condition(Expression.Equal(e, Expression.Constant(null)),
                Expression.NotEqual(e, Expression.Constant(null)),
                Expression.Condition(Expression.Equal(Expression.Property(e, fieldName), Expression.Constant(null)),
                Expression.NotEqual(e, Expression.Constant(null)), Expression.Call(m, mi, c)));
                return Expression.Lambda<Func<T, bool>>(call, e);
            }
            else
            {
                Expression call = Expression.Condition(Expression.Equal(e, Expression.Constant(null)),
                Expression.NotEqual(e, Expression.Constant(null)),
                Expression.Condition(Expression.Equal(Expression.Property(e, fieldName), Expression.Constant(null)),
                Expression.NotEqual(e, Expression.Constant(null)), Expression.Not(Expression.Call(m, mi, c))));
                return Expression.Lambda<Func<T, bool>>(call, e);
            }
        }
