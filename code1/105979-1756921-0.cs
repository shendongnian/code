    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace UniqueEmailAddresses
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string input 
                = "bob@example.com; sally@example.com; fred@example.com; sally@example.com";
                var result = input.Replace(" ", "").Split(';').Distinct();
                foreach( var addy in result)
                {
                    Console.WriteLine(addy);
                }
                Console.ReadKey();
    
            }
        }
    }
