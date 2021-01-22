        internal static INotifyPropertyChanged SubModel<T, TProperty>(T model, Expression<Func<T, TProperty>> pickProperty) where T : INotifyPropertyChanged
        {
            MemberExpression memberExpression = (MemberExpression)pickProperty.Body;
            ParameterExpression parameterExpression = pickProperty.Parameters[0];
            Expression mem = memberExpression.Expression;
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), mem.Type);
            LambdaExpression lambdaExpression = Expression.Lambda(delegateType, mem, parameterExpression);
            object subModel = lambdaExpression.Compile().DynamicInvoke(model);
            return subModel as INotifyPropertyChanged ?? model;
        }
