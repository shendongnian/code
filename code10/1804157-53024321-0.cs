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
            Console.WriteLine($"Counters: Static = {_staticCounter}, Instance = {_instanceCounter}");
        }
    }
