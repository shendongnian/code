    public class Base 
    {
        //Other stuff
        
        public static void DoSomething()
        {
            Console.WriteLine("Base");
        }
    }
    public class SomeClass : Base
    {
        public new static void DoSomething()
        {
            Console.WriteLine("SomeClass");
        }
    }
    public class SomeOtherClass : Base
    {
    }
