    class Demo
    {
        public static void Main()
        {
            System.Console.WriteLine(OuterClass.NestedClass.x);     
        }
    }
    
    class OuterClass
    {
        public class NestedClass
        {
            public static int x = 100;
        }
    }
