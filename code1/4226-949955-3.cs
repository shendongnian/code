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
                int count = collection.Count();
                for(int i = 0;  i < count; ++i)
                {
                    Console.Write("{0}{1}", collection[i].ToString(), delimiter);
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
                Console.Read();
            }
        }
    }
