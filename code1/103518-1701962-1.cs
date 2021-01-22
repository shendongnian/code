    using System; // includes our new delegates
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static IEnumerable<U> Map<T, U>(IEnumerable<T> input, Func<T, U> f)
            {
                foreach (T t in input)
                {
                    yield return f(t);
                }
            }
    
            static void Main(string[] args)
            {
                int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                foreach(String s in Map<int, string>(numbers, delegate(int i) { return String.Format("{0}^2 = {1}", i, i*i); }))
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
        }
    }
