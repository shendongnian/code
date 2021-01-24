    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static IEnumerable<string> zipCodes = new string[] { "90210", "94102", "98101", "80014" };
    
            static void Main(string[] args)
            {
                
                Console.WriteLine("enter a 5 digit zip code to see if it is supported in our area, or '0' to exit");
                do {
                    // Read next line
                    string userZip = Console.ReadLine().Trim();
    
                    // Exit program?
                    if (userZip == "0")
                        break;
    
                    // Validate input
                    if (userZip.Length != 5)
                    {
                        Console.WriteLine("ERROR: Zip code {0} is {1} characters; expected 5", userZip, userZip.Length);
                        continue;
                    }
                    int n;
                    bool isNumeric = int.TryParse(userZip, out n);
                    if (!isNumeric)
                    {
                        Console.WriteLine("ERROR: Zip code {0} must be numeric", userZip);
                        continue;
                    }
    
                    // Finally, see if our zip code matches a zip code in the list
                    bool found = zipCodes.Contains(userZip);
                    if (found)
                    {
                        Console.WriteLine("We support zip code {0}", userZip); ;
                    }
                    else
                    {
                        Console.WriteLine("We do not support " + userZip);
                    }
                } while (true);
                Console.WriteLine("Done: exiting program");
            } 
        }
    }
