    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class someBase { }
        class someChild : someBase { } 
        class Program
        {
            static void Main(string[] args)
            {
                var c = new Container<someBase>();
                IEnumerable<someChild> test = new List<someChild>();
                Console.WriteLine(c.DoStuff(new someChild()));
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
        public class Container<T> : BaseContainer<T>{}
        public static class ContainerExtension
        {
            public static string DoStuff<T, Tother>(this Container<T> container, IEnumerable<Tother> collection) where Tother : T
            {
                return "child";
            }
        }
    }
