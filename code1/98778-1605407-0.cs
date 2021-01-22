    class Program
    {
        static void Main(string[] args)
        {
            var b = new bar();
            var a = b.buzz().fizz(x => x.name).buzz().fizz();
            Console.ReadLine();
        }
    }
    public static class fooExtensions
    {
        public static T fizz<T>(this T t) where T : foo
        { return t; }
        public static T fizz<T>(this T t,
            Func<T, object> superlambda)
            where T : foo
        {
            return t;
        }
    }
    public class foo { public string name { get; set; } }
    public class bar : foo
    {
        public bar buzz()
        {
            return this;
        }
    }
