    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace OverallCalculator
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool shouldContinue = true;
    
                while (shouldContinue)
                {
                    int strikingLevel = GetValue("Enter Striking Level: ");
                    int grapplingLevel = GetValue("Enter Grappling Level: ");
                    int submissionLevel = GetValue("Enter Submission Level: ");
                    int durabilityLevel = GetValue("Enter Durability Level: ");
                    int technicalLevel = GetValue("Enter Technical Level: ");
                    int speedLevel = GetValue("Enter Speed Level: ");
                    int hardcoreLevel = GetValue("Enter Hardcore Level: ");
                    int charismaLevel = GetValue("Enter Charisma Level: ");
    
                    int total = strikingLevel + grapplingLevel + durabilityLevel + submissionLevel +
                        technicalLevel + speedLevel + charismaLevel + hardcoreLevel;
    
                    int overall = total / 8 + 8;
                    
                    Console.WriteLine("\nThe Overall is {0}.", overall);
                    while (true)
                    {
                        Console.WriteLine("Do you wish to continue? y/n? ");
                        string response = Console.ReadLine();
                        if (response.Equals("y", StringComparison.CurrentCultureIgnoreCase) ||
                            response.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                        {
                            shouldContinue = true;
                            break;
                        }
                        else if (response.Equals("n", StringComparison.CurrentCultureIgnoreCase) ||
                            response.Equals("no", StringComparison.CurrentCultureIgnoreCase))
                        {
                            shouldContinue = false;
                            break;
                        }
                    }
                } 
            }
    
            private static int GetValue(string prompt)
            {
                while (true)
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine();
                    int value;
                    if (int.TryParse(input, out value))
                    {
                        if (value <= 0)
                            Console.WriteLine("Please enter a positive number.");
                        else
                            return value;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number.");
                    }
                }
            }
        }
    }
