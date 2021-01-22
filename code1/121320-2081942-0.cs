    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    namespace dr.IfNotNullOperator.PoC
    {
        public static class ObjectExtensions
        {
            public static TResult IfNotNull<TArg,TResult>(this TArg arg, Expression<Func<TArg,TResult>> expression)
            {
                if (expression == null)
                    throw new ArgumentNullException("expression");
    
                if (ReferenceEquals(arg, null))
                    return default(TResult);
    
                var stack = new Stack<MemberExpression>();
                var expr = expression.Body as MemberExpression;
                while(expr != null)
                {
                    stack.Push(expr);
                    expr = expr.Expression as MemberExpression;
                } 
    
                if (stack.Count == 0 || !(stack.Peek().Expression is ParameterExpression))
                    throw new ApplicationException(String.Format("The expression '{0}' contains unsupported constructs.",
                                                                 expression));
                
                object a = arg;
                while(stack.Count > 0)
                {
                    expr = stack.Pop();
                    var p = expr.Expression as ParameterExpression;
                    if (p == null)
                    {
                        p = Expression.Parameter(a.GetType(), "x");
                        expr = expr.Update(p);
                    }
                    var lambda = Expression.Lambda(expr, p);
                    Delegate t = lambda.Compile();                
                    a = t.DynamicInvoke(a);
                    if (ReferenceEquals(a, null))
                        return default(TResult);
                }
    
                return (TResult)a;            
            }
        }
    }
