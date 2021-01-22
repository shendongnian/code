    internal class Program
    {
        static void Main(string[] args)
        {
            var fizzHandler = new Fizz();
            var context = new Context();
            Handle<Bar>.With(fizzHandler, context);
        }
    }
    public class Bar { }
    public class Event<T> { }
    public class Fizz : Event<Bar> { }
    public class Context { };
    public static class Handle<T>
    {
        public static void With(Event<T> e, Context c)
        {
            //do your stuff
        }
    }
