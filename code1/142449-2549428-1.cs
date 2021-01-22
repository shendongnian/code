    class OuterClass
    {
        public static int y = 100;
    
        public class NestedClass
        {
            public static void abc()
            {
                System.Console.WriteLine(OuterClass.y);     
            }
        }
    }
