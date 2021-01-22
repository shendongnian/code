using System;
using System.Collections.Generic;
using System.Reflection;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var anonymous = p.GetList(new[]{
                new { Id = 1, Name = "Foo" },       
                new { Id = 2, Name = "Bar" }
            });
            p.WriteList(anonymous);
        }
        private List<T> GetList<T>(params T[] elements)
        {
            var a = TypeGenerator(elements);
            return a;
        }
        public static List<T> TypeGenerator<T>(T[] at)
        {
            return new List<T>(at);
        }
        private void WriteList<T>(List<T> elements)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();
            foreach (var el in elements)
            {
                foreach (var p in pi)
                {
                    Console.WriteLine("{0}", p.GetValue(el, null));
                }
            }
            Console.ReadLine();
        }
    }
}
</pre>
