    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    namespace BinaryOpGenericTest
    {
        [Flags]
        enum MyFlags
        {
            A = 1,
            B = 2,
            C = 4
        }
        static class EnumExtensions
        {
            private static Dictionary<Type, Delegate> m_operations = new Dictionary<Type, Delegate>();
            public static bool IsFlagSet<T>(this T firstOperand, T secondOperand) 
                                                      where T : struct
            {
                Type enumType = typeof(T);
            
            
                if (!enumType.IsEnum)
                {
                    throw new InvalidOperationException("Enum type parameter required");
                }
                Delegate funcImplementorBase = null;
                m_operations.TryGetValue(enumType, out funcImplementorBase);
                Func<T, T, bool> funcImplementor = funcImplementorBase as Func<T, T, bool>;
            
                if (funcImplementor == null)
                {
                    funcImplementor = buildFuncImplementor(secondOperand);
                }
                return funcImplementor(firstOperand, secondOperand);
            }
            private static Func<T, T, bool> buildFuncImplementor<T>(T val)
                                                                where T : struct
            {
                var first = Expression.Parameter(val.GetType(), "first");
                var second = Expression.Parameter(val.GetType(), "second");
                    
                Expression convertSecondExpresion = Expression.Convert(second, typeof(int));
                var andOperator = Expression.Lambda<Func<T, T, bool>>(Expression.Equal(
                                                                                                           Expression.And(
                                                                                                                Expression.Convert(first, typeof(int)),
                                                                                                                 convertSecondExpresion),
                                                                                                           convertSecondExpresion),
                                                                                                 new[] { first, second });
                Func<T, T, bool> andOperatorFunc = andOperator.Compile();
                m_operations[typeof(T)] = andOperatorFunc;
                return andOperatorFunc;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyFlags flag = MyFlags.A | MyFlags.B;
                Console.WriteLine(flag.IsFlagSet(MyFlags.A));            
                Console.WriteLine(EnumExtensions.IsFlagSet(flag, MyFlags.C));
                Console.ReadLine();
            }
        }
    }
