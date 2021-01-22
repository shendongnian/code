    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    class Test
    {
        static IEnumerable<char> CapitalLetters(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(input);
            }
            foreach (char c in input)
            {
                yield return char.ToUpper(c);
            }
        }
        
        static void Main()
        {
            // Test that null input is handled correctly
            try
            {
                CapitalLetters(null);
                Console.WriteLine("An exception should have been thrown!");
            }
            catch (ArgumentNullException)
            {
                // Expected
            }
        }
    }
