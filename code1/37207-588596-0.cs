        using System;
        using System.Linq;
        using System.Reflection;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    MethodInfo foo1 = typeof(Example).GetGenericMethod("Foo",
                        new[] { typeof(string) },
                        new[] { typeof(int) },
                        typeof(void));
                    MethodInfo foo2 = typeof(Example).GetGenericMethod("Foo",
                        new[] { typeof(string), typeof(int) },
                        new[] { typeof(int) },
                        typeof(void));
                    MethodInfo foo3 = typeof(Example).GetGenericMethod("Foo",
                        new[] { typeof(string) },
                        new[] { typeof(string) },
                        typeof(void));
                    MethodInfo foo4 = typeof(Example).GetGenericMethod("Foo",
                        new[] { typeof(string), typeof(int) },
                        new[] { typeof(int), typeof(string) },
                        typeof(string));
                    Console.WriteLine(foo1.Invoke(null, new object[] { 1 }));
                    Console.WriteLine(foo2.Invoke(null, new object[] { 1 }));
                    Console.WriteLine(foo3.Invoke(null, new object[] { "s" }));
                    Console.WriteLine(foo4.Invoke(null, new object[] { 1, "s" }));
                }
            }
            public class Example
            {
                public static void Foo<T>(int ID) { }
                public static void Foo<T, U>(int ID) { }
                public static void Foo<T>(string ID) { }
                public static string Foo<T, U>(int intID, string ID) { return ID; }
            }
            public static class Extensions
            {
                public static MethodInfo GetGenericMethod(this Type t, string name, Type[] genericArgTypes, Type[] argTypes, Type returnType)
                {
                    MethodInfo foo1 = (from m in t.GetMethods(BindingFlags.Public | BindingFlags.Static)
                                       where m.Name == name &&
                                             m.GetGenericArguments().Length == genericArgTypes.Length &&
                                             m.GetParameters().Select(pi => pi.ParameterType).SequenceEqual(argTypes) &&
                                             m.ReturnType == returnType
                                       select m).Single().MakeGenericMethod(genericArgTypes);
                    return foo1;
                }
            }
        }
