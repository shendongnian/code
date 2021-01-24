        static LambdaExpression CreateExpression<TModel>(string propertyName)
        {
            var t = typeof(TModel);
            var param = Expression.Parameter(typeof(TModel), "x");
            //get the type for the 2nd generic arg
            var propType = t.GetProperty(propertyName).PropertyType;
            //make the generic type Func<TModel, TProp>
            Type genericFuncType = typeof(Func<,>).MakeGenericType(new Type[] { typeof(TModel), propType });
            //get the Expression.Lambda method
            MethodInfo mi = typeof(Expression).GetMethods().First(a => a.Name == "Lambda" && a.GetParameters().Length == 2);
            //get the Expression.Lambda<Func<TModel, TProp>> method
            MethodInfo mi2 = mi.MakeGenericMethod(new Type[] { genericFuncType });
            //Call Expression.Lambda<Func<TModel, TProp>>
            return (LambdaExpression)mi2.Invoke(null, new object[] { Expression.PropertyOrField(param, propertyName), new ParameterExpression[] { param }});
        }
