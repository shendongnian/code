    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            CultureInfo invariant = CultureInfo.InvariantCulture;
            string text = "0.5";
            decimal parsed = decimal.Parse(text, invariant);
            string reformatted = parsed.ToString("0.00", invariant);
            decimal reparsed = decimal.Parse(reformatted, invariant);
            
            Console.WriteLine(reparsed.ToString(invariant)); // Prints 0.50
        }
    }
