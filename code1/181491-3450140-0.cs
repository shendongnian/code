    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static bool Method(Expression<Func<int, bool>> predicate, int value)
            {
                return predicate.Compile()(value);
            }
    
    
            static void Main(string[] args)
            {
                Func<int, bool> testPredicate = n => n == 1;
                
                MethodInfo method = testPredicate.Method;
                var output = CreateExpression<Func<int, bool>>(method, (typeArguments, parameterExpressions) => Expression.Call(method.DeclaringType, method.Name, typeArguments, ProvideStrongArgumentsFor(method, parameterExpressions)));
                Console.WriteLine(Method(output, 3));
                Console.WriteLine(Method(output, 1));
            }
    
            private static Type[] GetTypeArgumentsFor(MethodBase method)
            {
                var typeArguments = method.GetGenericArguments();
                return (typeArguments.Length > 0) ? typeArguments : null;
            }
    
            private static ParameterExpression[] ExtractParameterExpressionsFrom<TDelegate>()
            {
                return typeof(TDelegate)
                    .GetMethod("Invoke")
                    .GetParameters()
                    .Select((parameter, index) => Expression.Parameter(parameter.ParameterType, "arg" + index))
                    .ToArray();
            }
    
            private static void CheckParameterCountsAreEqual(
                IEnumerable<ParameterExpression> delegateParameters,
                IEnumerable<ParameterInfo> methodParameters)
            {
                if (delegateParameters.Count() != methodParameters.Count())
                    throw new InvalidOperationException(
                        "The number of parameters of the requested delegate does not match " +
                        "the number parameters of the specified method.");
            }
    
            private static Expression[] ProvideStrongArgumentsFor(
                MethodInfo method, ParameterExpression[] parameterExpressions)
            {
                return method.GetParameters()
                    .Select((parameter, index) =>
                        Expression.Convert(parameterExpressions[index],
                                           parameter.ParameterType))
                    .ToArray();
            }
    
            private static Expression<TDelegate> CreateExpression<TDelegate>(MethodBase method,
                    Func<Type[], ParameterExpression[], MethodCallExpression> getCallExpression)
            {
                var parameterExpressions = ExtractParameterExpressionsFrom<TDelegate>();
                CheckParameterCountsAreEqual(parameterExpressions, method.GetParameters());
    
                var call = getCallExpression(GetTypeArgumentsFor(method), parameterExpressions);
    
                var lambda = Expression.Lambda<TDelegate>(call, parameterExpressions);
                return lambda;
            }
        }
    }
