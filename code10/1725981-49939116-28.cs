    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Foo(Func<Task> func) => Console.WriteLine("Foo1");
        static void Foo(Func<Task<int>> func) => Console.WriteLine("Foo2");
        static void Bar(Action action) => Console.WriteLine("Bar1");
        static void Bar(Func<int> action) => Console.WriteLine("Bar2");
        static void Main(string[] args)
        {
            Foo(async () => { while (true); });
            Bar(() => { while (true) ; });
        }
    }
