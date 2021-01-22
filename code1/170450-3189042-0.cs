    private  Expression<IsWordChar> CreateIsWordCharExpression()
    {
        var e = Expression.Parameter(typeof(int), "e");
        var c = Expression.Variable(typeof(char), "c");
        var returnLabel = Expression.Label(Expression.Label(typeof(bool)), _falseConstant);
        var lambda = Expression.Lambda<IsWordChar>(
            Expression.Block(
                new[] { c },
                Expression.IfThen(
                    Expression.OrElse(
                        Expression.Equal(e, Expression.Constant(-1)),
                        Expression.Equal(e, _inputLengthVar)
                    ),
                    Expression.Return(returnLabel.Target, _falseConstant)
                ),
                Expression.Assign(c, Expression.MakeIndex(_str, _stringCharsPropertyInfo, new[] { e })),
                Expression.IfThenElse(
                    Expression.OrElse(
                        Expression.OrElse(
                            Expression.OrElse(
                                Expression.AndAlso(
                                    Expression.GreaterThanOrEqual(c, Expression.Constant('a')),
                                    Expression.LessThanOrEqual(c, Expression.Constant('z'))
                                ),
                                Expression.AndAlso(
                                    Expression.GreaterThanOrEqual(c, Expression.Constant('A')),
                                    Expression.LessThanOrEqual(c, Expression.Constant('Z'))
                                )
                            ),
                            Expression.AndAlso(
                                Expression.GreaterThanOrEqual(c, Expression.Constant('0')),
                                Expression.LessThanOrEqual(c, Expression.Constant('1'))
                            )
                        ),
                        Expression.Equal(c, Expression.Constant('_'))
                    ),
                    Expression.Return(returnLabel.Target, _trueConstant),
                    Expression.Return(returnLabel.Target, _falseConstant)
                ),
                returnLabel
            ),
            "IsWordChar",
            new[] { e }
        );
        return lambda;
    }
