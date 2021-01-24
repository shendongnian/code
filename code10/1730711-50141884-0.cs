    using System;
    
    namespace Simpleton
    {
        class Program
        {
            static public int GetChoice()
            {
                int choice = 0;
                while (true)
                {
                    Console.Write("Enter number of rolls or \"quit\" to finish: ");
                    var answer = Console.ReadLine();
                    if (String.Compare(answer, "quit", true) == 0)
                    {
                        return 0; // Done
                    }
                    if (Int32.TryParse(answer, out choice))
                    {
                        return choice;
                    }
                }
            }
    
            static void Main(string[] args)
            {
                var choice = 0;
                while ((choice = GetChoice()) > 0)
                {
                    Console.WriteLine($"You'll be looping {choice} times.");
                    for (int tries = 0; tries < choice; tries++)
                    {
                        // Looping
                    }
                }
            }
        }
    }
