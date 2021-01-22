    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace SO2433436
    {
        class Program
        {
            static void LogObject<T>(T t)
            {
                Console.WriteLine("The object has static type '" + typeof(T).FullName + "',  dynamic type '" + t.GetType() + "', and value '" + t.ToString() + "'");
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine("What type would you like to use?");
                string typeName = Console.ReadLine();
    
                Type userType;
                switch (typeName)
                {
                    case "byte": userType = typeof(byte); break;
                    case "sbyte": userType = typeof(sbyte); break;
                    case "ushort": userType = typeof(ushort); break;
                    case "short": userType = typeof(short); break;
                    case "uint": userType = typeof(uint); break;
                    case "int": userType = typeof(int); break;
                    case "string": userType = typeof(string); break;
                    case "decimal": userType = typeof(decimal); break;
                    default:
                        userType = Type.GetType(typeName);
                        break;
                }
    
                Console.WriteLine("Selected type '" + userType.ToString() + "'");
    
                Console.WriteLine("Input Value:");
                string val = Console.ReadLine();
    
                object o = TypeDescriptor.GetConverter(userType).ConvertFrom(val);
    
                Console.WriteLine("<<<USING object>>>");
                LogObject(o);
    
                Console.WriteLine("<<<USING dynamic>>>");
                LogObject((dynamic)o);
    
                Console.WriteLine("<<<USING reflection>>>");
                Action<object> f = LogObject<object>;
                MethodInfo logger = f.Method.GetGenericMethodDefinition().MakeGenericMethod(userType);
                logger.Invoke(null, new[] { o });
    
                Console.WriteLine("<<<USING expression tree>>>");
                var p = new[] { Expression.Parameter(typeof(object)) };
                Expression<Action<object>> e =
                    Expression.Lambda<Action<object>>(
                        Expression.Call(null,
                                        logger,
                                        Expression.Convert(p[0], userType)
                                       )
                    , p);
                Action<object> a = e.Compile();
                a(o);
            }
        }
    }
