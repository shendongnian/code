    using System;
    using System.Globalization;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            CultureInfo turkish = CultureInfo.CreateSpecificCulture("tr");
            Thread.CurrentThread.CurrentCulture = turkish;                
    
            // In Turkey, "i" does odd things
            string lower = "i";
            string upper = "I";
            
            Console.WriteLine(lower.Equals(upper, 
                StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine(lower.Equals(upper, 
                StringComparison.InvariantCultureIgnoreCase));
        }
    }
