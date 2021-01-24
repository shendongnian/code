    var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(
                new System.Linq.Expressions.ParameterExpression[] { },
                typeof(bool),
                "100 > 1000",
                new object[] { });
            var compiledDelegate = expression.Compile();
            var result = compiledDelegate.DynamicInvoke(null);
