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
                var output = ConvertFuncToExpression(testPredicate);
                Console.WriteLine(Method(output, 3));
                Console.WriteLine(Method(output, 1));
            }
    
            private static Expression<TDelegate> CreateExpression<TDelegate>(MethodBase method)
            {
                var delegateArguments = typeof(TDelegate).GetMethod("Invoke").GetParameters().Select((parameter, index) => Expression.Parameter(parameter.ParameterType, "param_" + index)).ToArray();
                if (delegateArguments.Count() != method.GetParameters().Count()) throw new InvalidOperationException("The number of parameters of the requested delegate does not match the number parameters of the specified method.");
    
                var argumentsTypes = method.GetGenericArguments();
                argumentsTypes = (argumentsTypes.Length > 0) ? argumentsTypes : null;
                var convertedArguments = method.GetParameters().Select((parameter, index) => Expression.Convert(delegateArguments[index], parameter.ParameterType)).ToArray();
                var call = Expression.Call(method.DeclaringType, method.Name, argumentsTypes, convertedArguments);
    
                var lambda = Expression.Lambda<TDelegate>(call, delegateArguments);
                return lambda;
            }
    
            private static Expression<Func<TIn1, TOut>> ConvertFuncToExpression<TIn1, TOut>(Func<TIn1, TOut> input)
            {
                MethodInfo method = input.Method;
                return CreateExpression<Func<TIn1, TOut>>(method);
            }
        }
    }
