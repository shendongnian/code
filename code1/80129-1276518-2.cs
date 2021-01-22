        //I want the equal of the following statement in C# Linq Expression
        Expression<Func<bool>> test =
            Expression.Lambda<Func<bool>>(
                Expression.OrElse(
                    Expression.AndAlso(
                        Expression.Invoke(featureEnabledExpTree,
                            Expression.Constant("MV"),
                            Expression.Constant("")
                        ),
                        Expression.Invoke(featureEnabledExpTree,
                            Expression.Constant("GAS"),
                            Expression.Constant("G")
                        )
                    ),
                    Expression.Not(
                        Expression.Invoke(featureEnabledExpTree,
                            Expression.Constant("GAS"),
                            Expression.Constant("F")
                        )
                    )
                )
            );
        bool isMatch = test.Compile()();
