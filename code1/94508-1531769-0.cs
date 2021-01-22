        class Program
        {
            public static void RoundToFive()
            {
                Console.WriteLine(R(71));
                Console.WriteLine(R(72.5));  //70 or 75?  depends on midpoint rounding
                Console.WriteLine(R(73.5));
                Console.WriteLine(R(75));
            }
    
            public static double R(double x)
            {
                return Math.Round(x/5, MidpointRounding.AwayFromZero)*5;
            }
    
            static void Main(string[] args)
            {
                RoundToFive();
            }
        }
