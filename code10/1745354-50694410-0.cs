    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace ConsoleApp41
    {
        class Program
        {
            static void Main(string[] args)
            {
                string tokens = Console.ReadLine();
                List<string> list = tokens.Split('|').ToList();
                List<string> listTwo = new List<string>(list.Count);
    
                foreach (var token in list)
                {
                    // the following line won't do anything
                    // as you don't assign its result to a variable
                    token.Split(" ");
                    // so you are only adding every token from list in listTwo
                    listTwo.Add(token);
                }
                // at this point, the content of list and listTwo are the same
    
                foreach (var token in listTwo)
                {
                    // you are iterating through 'listTwo', and you don't even
                    // use 'token', so what's that foreach for?
                    // do you really believe 'listTwo' contains that much " "?
                    // as a reminder, listTwo = { "1 2 3 ", "4 5 6 ", " 7 8" }
                    listTwo.Remove(" ");
                }
    
                for (int i = 0; i < listTwo.Count; i++)
                {
                    // here you just print the original 'tokens' without '|'
                    Console.Write(listTwo[i]);
                }
            }
        }
    }
