    using System;
    using System.Linq;
    
    public class Program
    {
        public static bool MyValue = false;
    
        public static DateTime lastChange { get; set; } = DateTime.MinValue;
    
        public static void ChangeValue(bool b)
        {
            // do nothing if not 2s passed since last trigger AND the value is different
            // dont reset the timer if we would change it to the same value
            if (DateTime.Now - lastChange < TimeSpan.FromSeconds(2) || MyValue == b)
                return;
            // change it and remember change time
            lastChange = DateTime.Now;
            MyValue = b;
            Console.WriteLine($"Bool changed from {!b} to {b}. Time: {lastChange.ToLongTimeString()}");
        }
    
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10000000; i++)
            {
                ChangeValue(!MyValue);
            }
        }
    }
