    class TestApp
    {
        // Define a new class called 'System' to cause problems.
        public class System { }
        // Define a constant called 'Console' to cause more problems.
        const int Console = 7;
        const int number = 66;
        static void Main()
        {
            // Error  Accesses TestApp.Console
            Console.WriteLine(number);
            // Error either
            System.Console.WriteLine(number);
            // This, however, is fine
            global::System.Console.WriteLine(number);
        }
    }
