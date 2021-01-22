    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            Compare("mun", "mün");
            Compare("muna", "münb");
            Compare("munb", "müna");
        }
        
        static void Compare(string x, string y)
        {
            int result = string.Compare(x, y, true, 
                                       CultureInfo.InvariantCulture));
            Console.WriteLine("{0}; {1}; {2}", x, y, result);
        }
    }
