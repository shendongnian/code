    using System;
    using System.Collections.Generic;
    namespace MethodResolutionExploit
    {
        public class BaseContainer<T> : IEnumerable<T>
        {
            public void DoStuff(T item) { Console.WriteLine("\tbase"); }
            public IEnumerator<T> GetEnumerator() { return null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return null; }
        }        
        public class Container<T> : BaseContainer<T> { }
        public class ContainerChild<T> : Container<T> { }
        public class ContainerChildWithOverride<T> : Container<T> { }
        public static class ContainerExtension
        {
            public static void DoStuff<T, Tother>(this Container<T> container, IEnumerable<Tother> collection) where Tother : T
            {
                Console.WriteLine("\tContainer.DoStuff<Tother>()");
            }
            public static void DoStuff<T, Tother>(this ContainerChildWithOverride<T> container, IEnumerable<Tother> collection) where Tother : T
            {
                Console.WriteLine("\tContainerChildWithOverride.DoStuff<Tother>()");
            }
        }
        
        class someBase { }
        class someChild : someBase { }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("BaseContainer:");
                var baseContainer = new BaseContainer<string>();
                baseContainer.DoStuff("");
                Console.WriteLine("Container:");
                var container = new Container<string>();
                container.DoStuff("");
                container.DoStuff(new List<string>());
                Console.WriteLine("ContainerChild:");
                var child = new ContainerChild<string>();
                child.DoStuff("");
                child.DoStuff(new List<string>());
                Console.WriteLine("ContainerChildWithOverride:");
                var childWithOverride = new ContainerChildWithOverride<string>();
                childWithOverride.DoStuff("");
                childWithOverride.DoStuff(new List<string>());
                //note covariance
                Console.WriteLine("Covariance Example:");
                var covariantExample = new Container<someBase>();
                var covariantParameter = new Container<someChild>();
                covariantExample.DoStuff(covariantParameter);
                
                // this won't work though :(
                // var covariantExample = new Container<Container<someBase>>();
                // var covariantParameter = new Container<Container<someChild>>();
                // covariantExample.DoStuff(covariantParameter);
                Console.ReadKey();
            }
        }
    }
