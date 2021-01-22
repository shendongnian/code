    public static class Dereferencer
    {
        private static readonly MethodInfo safeDereferenceMethodInfo 
            = typeof (Dereferencer).GetMethod("SafeDereferenceHelper", BindingFlags.NonPublic| BindingFlags.Static);
        private static TMember SafeDereferenceHelper<TTarget, TMember>(TTarget target,
                                                                Func<TTarget, TMember> walker)
        {
            return target == null ? default(TMember) : walker(target);
        }
        public static TMember SafeDereference<TTarget, TMember>(this TTarget target, Expression<Func<TTarget, TMember>> expression)
        {
            var lambdaExpression = expression as LambdaExpression;
            if (lambdaExpression == null)
                return default(TMember);
            var methodCalls = new Queue<MethodCallExpression>();
            VisitExpression(expression.Body, methodCalls);
            var callChain = methodCalls.Count == 0 ? expression.Body : CombineMethodCalls(methodCalls);
            var exp = Expression.Lambda(typeof (Func<TTarget, TMember>), callChain, lambdaExpression.Parameters);
            var safeEvaluator = (Func<TTarget, TMember>) exp.Compile();
            return safeEvaluator(target);
        }
        private static Expression CombineMethodCalls(Queue<MethodCallExpression> methodCallExpressions)
        {
            var callChain = methodCallExpressions.Dequeue();
            if (methodCallExpressions.Count == 0)
                return callChain;
            return Expression.Call(callChain.Method, 
                                   CombineMethodCalls(methodCallExpressions), 
                                   callChain.Arguments[1]);
        }
        private static MethodCallExpression GenerateSafeDereferenceCall(Type targetType,
                                                                        Type memberType,
                                                                        Expression target,
                                                                        Func<ParameterExpression, Expression> bodyBuilder)
        {
            var methodInfo = safeDereferenceMethodInfo.MakeGenericMethod(targetType, memberType);
            var lambdaType = typeof (Func<,>).MakeGenericType(targetType, memberType);
            var lambdaParameterName = targetType.Name.ToLower();
            var lambdaParameter = Expression.Parameter(targetType, lambdaParameterName);
            var lambda = Expression.Lambda(lambdaType, bodyBuilder(lambdaParameter), lambdaParameter);
            return Expression.Call(methodInfo, target, lambda);
        }
        private static void VisitExpression(Expression expression, 
                                            Queue<MethodCallExpression> methodCallsQueue)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    VisitMemberExpression((MemberExpression) expression, methodCallsQueue);
                    break;
                case ExpressionType.Call:
                    VisitMethodCallExpression((MethodCallExpression) expression, methodCallsQueue);
                    break;
            }
        }
        private static void VisitMemberExpression(MemberExpression expression, 
                                                  Queue<MethodCallExpression> methodCallsQueue)
        {
            var call = GenerateSafeDereferenceCall(expression.Expression.Type,
                                                   expression.Type,
                                                   expression.Expression,
                                                   p => Expression.PropertyOrField(p, expression.Member.Name));
            methodCallsQueue.Enqueue(call);
            VisitExpression(expression.Expression, methodCallsQueue);
        }
        private static void VisitMethodCallExpression(MethodCallExpression expression, 
                                                      Queue<MethodCallExpression> methodCallsQueue)
        {
            var call = GenerateSafeDereferenceCall(expression.Object.Type,
                                                   expression.Type,
                                                   expression.Object,
                                                   p => Expression.Call(p, expression.Method, expression.Arguments));
            methodCallsQueue.Enqueue(call);
            VisitExpression(expression.Object, methodCallsQueue);
        }
    }
