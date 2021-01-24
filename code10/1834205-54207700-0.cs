    using System;
    using System.Text.RegularExpressions;
    
    namespace RegexTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string inputString = @"ObjectID = '{A591C480-2979-48ED-9796-5C3149472E7A}' and ObjectID = { 90f0fb85 - 0f80 - 4466 - 9b8c - 2025949e2079 }";
                Console.WriteLine("Before: ");
                Console.WriteLine(inputString);
    
                var quotedGuidMatches = Regex.Matches(inputString, @"'[({]?\s?[a-zA-Z0-9]{8}\s?[-]?\s?([a-zA-Z0-9]{4}\s?[-]?\s?){3}\s?[a-zA-Z0-9]{12}\s?[})]?'");
    
                var guidMatches = Regex.Matches(inputString, @"\b[({]?\s?[a-zA-Z0-9]{8}\s?[-]?\s?([a-zA-Z0-9]{4}\s?[-]?\s?){3}\s?[a-zA-Z0-9]{12}\s?[})]?\b");
             
                //First eliminate single quotes from guoted guids
                foreach(var quotedGuid in quotedGuidMatches)
                {
                    inputString = inputString.Replace(quotedGuid.ToString(), quotedGuid.ToString().Trim('\''));
                }            
    
                //After single quotes have been eliminated from guids, surround all naked guids with single quotes
                inputString = Regex.Replace(inputString, @"\b[({]?\s?[a-zA-Z0-9]{8}\s?[-]?\s?([a-zA-Z0-9]{4}\s?[-]?\s?){3}\s?[a-zA-Z0-9]{12}\s?[})]?\b", "'$0'", RegexOptions.IgnoreCase);
    
                Console.WriteLine("\nAfter: ");
                Console.WriteLine(inputString);
    
                Console.ReadLine();
            }
        }
    }
