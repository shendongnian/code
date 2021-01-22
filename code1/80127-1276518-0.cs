        Expression<Func<bool>> test =
            Expression.Lambda<Func<bool>>(
                Expression.OrElse(
                    Expression.AndAlso(
                        Expression.Invoke(featureEnabledExpTree,
                            Expression.Constant("MV"),
                            Expression.Constant("")
                        ), // end Invoke
                        Expression.Invoke(featureEnabledExpTree,
                            Expression.Constant("GAS"),
                            Expression.Constant("G")
                        ) // end Invoke
                    ), // end AndAlso
                    Expression.Not(
                        Expression.Invoke(featureEnabledExpTree,
                            Expression.Constant("GAS"),
                            Expression.Constant("F")
                        ) // end Invoke
                    ) // end Not
                ) // end OrElse
            ); // end Lambda
        bool isMatch = test.Compile()();
