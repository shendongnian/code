        class ICESMARK
    {
        public static int ICECount = 0;
        public static double average = 0;
        public ICESMARK(double Mark)
        {
           
            average += Mark;
            if (ICECount < 8) { ICECount++; }
            if (ICECount == 8) { average /= ICECount;}            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICESMARK[] ICE = new ICESMARK[8];
            double userInput;
            for (int counter = 0; counter < ICE.Length ; counter++)
            {
                Console.Write("Please enter your mark for ICE{0}: ", counter + 1 );
                bool ifInt = double.TryParse(Console.ReadLine(), out userInput);
                ICE[counter] = new ICESMARK(userInput);
                Console.WriteLine(ICESMARK.ICECount);
            }
            Console.WriteLine(ICESMARK.average);
            Console.WriteLine(ICESMARK.ICECount);
            Console.ReadLine();
        }
    }
