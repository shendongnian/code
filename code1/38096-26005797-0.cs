    public class Parent1
    {
        protected static void Foo()
        {
            Console.WriteLine("Parent1");
        }
    }
    
    public class Child : Parent1
    {
        public static void Foo()
        {
            return Parent1.Foo();
        }
    }
