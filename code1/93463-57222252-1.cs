    public class Util
    {
        // final prevents inheritance, just like C# static classes can't be inherited
        // final is basically like the C# sealed keyword.
        public static final class Math
        {
            // prevent constructor from being called
            private Math(){}
            static
            {
                // Acts like a C# static constructor. (only runs once, )
            }
            public static int Add(int num1, int num2)
            {
                return num1+num2;
            }
        }
    }
