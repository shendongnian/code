    class OuterClass
    {
        public int y = 100;
    
        public class NestedClass
        {
            public static void abc()
            {
                OuterClass oc = new OuterClass();
                System.Console.WriteLine(oc.y);     
            }
        }
    }
