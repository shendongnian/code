    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    class Program
    {
        static void Main()
        {
            string[] arr = { "abc", "def" };
            for (int i = 0; i < arr.Length; i++)
            {
                Foo(() => arr[i]);
            }
        }
        static object Foo<T>(Expression<Func<T>> lambda)
        {
            object obj = Walk(lambda.Body);
            Console.WriteLine("Value is: " + obj);
            return obj;
    
        }
        static object Walk(Expression expr)
        {
            switch (expr.NodeType)
            {
                case ExpressionType.ArrayIndex:
    
                    BinaryExpression be = (BinaryExpression)expr;
                    Array arr = (Array)Walk(be.Left);
                    int index = (int) Walk(be.Right);
                    Console.WriteLine("Index is: " + index);
                    return arr.GetValue(index);
                case ExpressionType.MemberAccess:
                    MemberExpression me = (MemberExpression)expr;
                    switch (me.Member.MemberType)
                    {
                        case MemberTypes.Property:
                            return ((PropertyInfo)me.Member).GetValue(Walk(me.Expression), null);
                        case MemberTypes.Field:
                            return ((FieldInfo)me.Member).GetValue(Walk(me.Expression));
                        default:
                            throw new NotSupportedException();
                    }
                case ExpressionType.Constant:
                    return ((ConstantExpression) expr).Value;
                default:
                    throw new NotSupportedException();
    
            }
        }
    
    }
 
