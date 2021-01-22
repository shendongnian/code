    public class Helper
    {   
        static int i = 10; // This assignment will end up in a type initializer
        static Helper()
        {
            // Explicit type initializer
            // The compiler will make sure both, implicit and explicit initializations are run
        }
    }
