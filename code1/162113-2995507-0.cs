    public class Bus
    {
        public static int busNo = 0;
    
        static Bus()
        {
            Console.WriteLine("Woey, it's a new day! Drivers are starting to work.");
        }
    
        public Bus()
        {
            busNo++;
    
            Console.WriteLine("Bus #{0} goes from the depot.", busNo);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Bus busOne = new Bus();
            Bus busTwo = new Bus();
        }
    
        // Output:
        // Woey, it's a new day! Drivers are starting to work.
        // Bus #1 goes from the depot.
        // Bus #2 goes from the depot.
    }
