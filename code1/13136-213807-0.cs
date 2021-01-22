    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace GenericTest
    {
        public class House<T>
        {
            public House(params T[] values)
            {
                System.Console.WriteLine("Params T[]");
            }
            public House(int num, T defaultVal)
            {
                System.Console.WriteLine("int, T");
            }
    
            public static House<T> CreateFromDefault<T>(int count, T defaultVal)
            {
                return new House<T>(count, defaultVal);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                House<int> test = new House<int>(1, 2);                         // prints int, t
                House<int> test1 = new House<int>(new int[] {1, 2});            // prints parms
                House<string> test2 = new House<string>(1, "string");           // print int, t
                House<string> test3 = new House<string>("string", "string");    // print parms
                House<int> test4 = House<int>.CreateFromDefault<int>(1, 2);     // print int, t
            }
        }
    }
