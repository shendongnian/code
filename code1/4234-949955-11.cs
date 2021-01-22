    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleWritelineTest
    {
        public static class Extensions
        {
            public static void WriteToConsole<T>(this IList<T> collection)
            {
                WriteToConsole<T>(collection, "\t");
            }
    
            public static void WriteToConsole<T>(this IList<T> collection, string delimiter)
            {
                 collection.FastForEach(item => Console.Write("{0}{1}", item.ToString(), delimiter));
            }
    
            public static void FastForEach<T>(this IList<T> collection, Action<T> actionToPerform)
            {
                int count = collection.Count();
                for (int i = 0; i < count; ++i)
                {
                    actionToPerform(collection[i]);    
                }
                Console.WriteLine();
            }
        }
    
        internal class Foo
        {
            override public string ToString()
            {
                return "FooClass";
            }
        }
    
        internal class Program
        {
    
            static void Main(string[] args)
            {
                var myIntList = new List<int> {1, 2, 3, 4, 5};
                var myDoubleList = new List<double> {1.1, 2.2, 3.3, 4.4};
                var myDoubleArray = new Double[] {12.3, 12.4, 12.5, 12.6};
                var myFooList = new List<Foo> {new Foo(), new Foo(), new Foo()};
    
                // Using the standard delimiter /t
                myIntList.WriteToConsole();
                myDoubleList.WriteToConsole();
                myDoubleArray.WriteToConsole();
                myFooList.WriteToConsole();
    
                // Using our own delimiter ~
                myIntList.WriteToConsole("~");
    
                // What if we want to write them to separate lines?
                myIntList.FastForEach(item => Console.WriteLine(item.ToString()));
                Console.Read();
            }
        }
    }
