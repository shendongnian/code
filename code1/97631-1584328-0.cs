    using System;
    
    class Test
    {
        static void Main()
        {
            decimal dcm1 = 8224055000.0000000000m;
            decimal dcm2 = 8224055000m;
            double dbl1 = (double) dcm1;
            double dbl2 = (double) dcm2;
            
            Console.WriteLine(DoubleConverter.ToExactString(dbl1));
            Console.WriteLine(DoubleConverter.ToExactString(dbl2));
        }
    }
