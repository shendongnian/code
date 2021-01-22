    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Container<string> c = new Container<string>();
                List<string> test = new List<string>();
                Console.WriteLine(c.DoStuff("test"));
                Console.WriteLine(c.DoStuff(test));
                Console.ReadKey();
            }
        }
        public class BaseContainer<T> : IEnumerable<T>
        {
            public string DoStuff(T item) { return "base"; }
            public IEnumerator<T> GetEnumerator() { return null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return null; }
        }
        public class Container<T> : BaseContainer<T> { }
        public static class ContainerExtension
        {
            public static string DoStuff<T>(this Container<T> container, IEnumerable<T> collection)
            {
                return "Extension";
            }
        }
    }
