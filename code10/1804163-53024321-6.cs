    public class A
    {
        private static int _staticCounter;
        private int _instanceCounter;
        public void Count()
        {
            _staticCounter++;
            _instanceCounter++;
        }
        public void PrintCount()
        {
            Console.WriteLine($"Static = {_staticCounter}, Instance = {_instanceCounter}");
        }
        public static void PrintStatic()
        {
            Console.WriteLine($"Static = {_staticCounter}"); // Can only access static fields.
        }
    }
