     Expression<Func<T>> ToExpression<T>(Func<T> call)
            {
                MethodCallExpression methodCall = call.Target == null
                    ? Expression.Call(call.Method)
                    : Expression.Call(Expression.Constant(call.Target), call.Method);
    
                return Expression.Lambda<Func<T>>(methodCall);
            }
