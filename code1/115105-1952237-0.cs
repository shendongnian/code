    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Diagnostics;
    
    namespace ConsoleApplication2
    {
        class MyClass01
        {
            public String _ID;
    
            public override string ToString()
            {
                return _ID;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyClass01 oMy1 = new MyClass01();
                oMy1._ID = "1";
    
                MyClass01 oMy2 = new MyClass01();
                oMy2._ID = "3";
    
                IList<MyClass01> oListType01 = new List<MyClass01>();
    
                oListType01.Add(oMy1);
                oListType01.Add(oMy2);
    
                object oObjectType = new object();
    
                oObjectType = oListType01;
    
                Test(oObjectType);
    
                Console.In.ReadLine();
            }
    
            private static void Test(object oObjectType)
            {
                Type tObject = oObjectType.GetType();
                Debug.Assert(tObject.IsGenericType);
                Debug.Assert(tObject.GetGenericArguments().Length == 1);
                Type t = tObject.GetGenericArguments()[0];
    
                Type tIEnumerable = typeof(IEnumerable<>).MakeGenericType(t);
                Debug.Assert(tIEnumerable.IsAssignableFrom(tObject));
    
                MethodInfo mElementAt =
                    typeof(Enumerable)
                    .GetMethod("ElementAt")
                    .MakeGenericMethod(t);
    
                Console.Out.WriteLine("o[0] = " +
                    mElementAt.Invoke(null, new Object[] { oObjectType, 0 }));
                Console.Out.WriteLine("o[1] = " +
                    mElementAt.Invoke(null, new Object[] { oObjectType, 1 }));
            }
        }
    }
