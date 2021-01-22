    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            string text="one two 3 4 five";
            Regex num=new Regex(@"\G[0-9]+");
            
            Console.WriteLine("{0} {1}",
                              num.IsMatch(text, 8), // True
                              num.IsMatch(text, 0)); // False
        }
    }
