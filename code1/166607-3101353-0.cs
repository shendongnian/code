    private SomeViewModel CreateViewModel(SomeDto dto, Tier t, 
        Expression<Func<string, int, ActionResult>> actionToCall)
    {
        var methodCallExpression = (MethodCallExpression)actionToCall.Body;
        var param = Expression.Parameter(typeof(SomeController), null);
        return new SomeViewModel()
        {
            Action =
                Expression.Lambda<Action<SomeController>>(
                    Expression.Call(
                        param,
                        methodCallExpression.Method,
                        Expression.Constant(dto.Qualification.Name),
                        Expression.Constant(t.Id)),
                    param)
        };
    }
