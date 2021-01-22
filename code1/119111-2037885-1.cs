    using System;
    
    public interface IFoo {}
    public class Bar : IFoo {}
    public class Baz : Bar {}
    
    public static class Extensions
    {
        public static void Extension(this IFoo foo)
        {
            Console.WriteLine("Extension(IFoo)");
        }
    
        public static void Extension(this Bar bar)
        {
            Console.WriteLine("Extension(Bar)");
        }
    }
    
    public class Test
    {
        static void Main()
        {
            Baz b = new Baz();
            b.Extension();
        }
    }
