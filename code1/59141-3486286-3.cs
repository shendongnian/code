    public class Counter
    {
        private Counter() { }
        public static int currentCount;
        public static int IncrementCount()
        {
            return ++currentCount;
        }
    }
    
    class TestCounter
    {
        static void Main()
        {
            // If you uncomment the following statement, it will generate
            // an error because the constructor is inaccessible:
            // Counter aCounter = new Counter();   // Error
    
            Counter.currentCount = 100;
            Counter.IncrementCount();
            System.Console.WriteLine("New count: {0}", Counter.currentCount);
        }
    }
