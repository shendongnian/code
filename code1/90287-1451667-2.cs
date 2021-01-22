    var exp1 = Expression.Equal(Expression.Parameter(typeof(int),"value"), Expression.Property(Expression.New(typeof(Bar).GetConstructor(new Type[] { })), "Foo"));
                var exp2 = Expression.Equal(Expression.Parameter(typeof(int), "value"), Expression.Property(Expression.New(typeof(Foo).GetConstructor(new Type[] { })), "Bar"));
                var orExp = Expression.OrElse(exp1, exp2);
                var method = LambdaExpression.Lambda(orExp, Expression.Parameter(typeof(int), "value"));
                method.Compile();
