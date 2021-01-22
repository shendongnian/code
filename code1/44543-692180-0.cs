    static void Main(string[] args)
    {
        Console.WriteLine(Base.Hello());
        Console.WriteLine(Derived.Hello());
        Console.Read();
        /* output will be:
        Hello
        World
        */
    }
    public class Base
    {
        public static object Hello()
        {
            return "Hello";
        }
    }
    public class Derived : Base
    {
        public static new object Hello()
        {
            return "World";
        }
    }
