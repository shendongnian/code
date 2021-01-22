    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    class Test
    {
        static bool IsInstanceOfGenericType(Type genericType, object instance)
        {
            Type type = instance.GetType();
            while (type != null)
            {
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }
        
        static void Main(string[] args)
        {
            // True
            Console.WriteLine(IsInstanceOfGenericType(typeof(List<>),
                                                      new List<string>()));
            // False
            Console.WriteLine(IsInstanceOfGenericType(typeof(List<>),
                                                      new string[0]));
            // True
            Console.WriteLine(IsInstanceOfGenericType(typeof(List<>),
                                                      new SubList()));
            // True
            Console.WriteLine(IsInstanceOfGenericType(typeof(List<>),
                                                      new SubList<int>()));
        }
        
        class SubList : List<string>
        {
        }
        class SubList<T> : List<T>
        {
        }
    }
