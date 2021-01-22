    using System;
    using System.Collections.Generic;
    
    namespace TestDelegate
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> words = new List<string>() { "one", "two", "three", "four", "five" };
                Action<string> theFunction = WriteBasic;
    
                foreach (string word in words)
                {
                    theFunction(word);
                }
                Console.ReadLine();
            }
    
            public static void WriteBasic(string message)
            {
                Console.WriteLine(message);
            }
    
            public static void WriteAdvanced(string message)
            {
                Console.WriteLine("*** {0} ***", message);
            }
    
        }
    }
