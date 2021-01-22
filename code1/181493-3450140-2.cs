    using System;
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
                var output = ConvertFunc(testPredicate);
                Console.WriteLine(Method(output, 3));
                Console.WriteLine(Method(output, 1));
            }
    
            private static Expression<TDelegate> CreateExpression<TDelegate>(MethodBase method, Func<Type[], ParameterExpression[], MethodCallExpression> getCallExpression)
            {
    
                var parameterExpressions = typeof(TDelegate).GetMethod("Invoke").GetParameters().Select((parameter, index) => Expression.Parameter(parameter.ParameterType, "param_" + index)).ToArray();
                if (parameterExpressions.Count() != method.GetParameters().Count()) throw new InvalidOperationException("The number of parameters of the requested delegate does not match the number parameters of the specified method.");
    
                var typeArguments = method.GetGenericArguments();
                typeArguments = (typeArguments.Length > 0) ? typeArguments : null;
    
                var call = getCallExpression(typeArguments, parameterExpressions);
    
                var lambda = Expression.Lambda<TDelegate>(call, parameterExpressions);
                return lambda;
            }
    
            private static Expression[] ProvideStrongArgumentsFor(MethodInfo method, ParameterExpression[] parameterExpressions)
            {
                return method.GetParameters().Select((parameter, index) => Expression.Convert(parameterExpressions[index], parameter.ParameterType)) .ToArray();
            }
    
            private static Expression<Func<TInput, TOutput>> ConvertFunc<TInput, TOutput>(Func<TInput, TOutput> input)
            {
                MethodInfo method = input.Method;
                return CreateExpression<Func<TInput, TOutput>>(method, (typeArguments, parameterExpressions) => Expression.Call(method.DeclaringType, method.Name, typeArguments, ProvideStrongArgumentsFor(method, parameterExpressions)));
            }
        }
    }
