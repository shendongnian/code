    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;
    
    public static class FirstExtensions
    {
        public static void Foo(this string x) {}
        public static void Bar(string x) {} // Not an ext. method
        public static void Baz(this int x) {} // Not on string
    }
    
    public static class SecondExtensions
    {
        public static void Quux(this string x) {}
    }
    
    public class Test
    {
        static void Main()
        {
            Assembly thisAssembly = typeof(Test).Assembly;
            foreach (MethodInfo method in GetExtensionMethods(thisAssembly,
                typeof(string)))
            {
                Console.WriteLine(method);
            }
        }
        
        static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly,
            Type extendedType)
        {
            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        select method;
            return query;
        }
    }
