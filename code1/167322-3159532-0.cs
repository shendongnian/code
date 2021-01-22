    internal class Program
    {        
        static void Main(string[] args)
        {
            var fizzHandler = new Fizz();
            var context = new Context();
            Subscribe<Bar>.To(fizzHandler, context);
        }
    }
    public class Bar { }
    public class Event<T> { }
    public class Fizz : Event<Bar> { }
    public class Context { };
    public static class Subscribe<T>
    {
        public static void To(Event<T> e, Context c)
        {
            //do your stuff
        }
    }
