    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            string text = "A 101 B202 C 303 ";
            string output = Regex.Replace(text, @"(\p{L}) (\d)", @"$1$2");
            Console.WriteLine(output); // Prints A101 B202 C303
        }
    }
