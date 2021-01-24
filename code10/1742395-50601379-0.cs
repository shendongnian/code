    using System;
    using System.Reflection;
    using System.Linq;
    
    namespace AssemblyLoadRefelectionExp
    {
        public class MyClass
        {
            public string Key { get; set; }
        }
    
        public interface IDummy { }
    
        public interface IDummyDerived<T> : IDummy
        {
            void Foo(T value);
        }
    
        public interface ITempDerived<T> : IDummy
        {
            void HelloWorld(T value);
        }
    
        public class DummyDerived<T> : IDummyDerived<T>
        {
            public void Foo(T value)
            {
                Console.WriteLine("DummyDerived`1 ->Foo");
            }
        }
    
        public class AnotherDummy : IDummyDerived<string>
        {
            public void Foo(string value)
            {
                Console.WriteLine("AnotherDummy -> Foo");
            }
        }
    
        public class Program
        {
            public static void Main()
            {
                Console.WriteLine($"Is {typeof(DummyDerived<MyClass>)} equal to {typeof(IDummyDerived<MyClass>)} : {CheckType<DummyDerived<MyClass>>(typeof(IDummyDerived<MyClass>))}");
                Console.WriteLine("---------------------------------");
                GetDummy<IDummyDerived<string>>();
    
                Console.ReadLine();
            }
    
            public static bool CheckType<T>(Type type)
            {
                return typeof(T) == type ? true : false;
            }
    
            public static T GetDummy<T>() where T : IDummy
            {
                Type baseType = typeof(IDummy);
                Type[] types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(p => baseType.IsAssignableFrom(p) && p.IsClass).ToArray();
                //now I have all classes which implements one of my interfaces
                foreach (Type type in types)
                {
                    Console.WriteLine($"Is {type.Name} assignable from {typeof(T)} : {typeof(T).IsAssignableFrom(type)}");
                }
    
                return default(T);
            }
        }
    }
