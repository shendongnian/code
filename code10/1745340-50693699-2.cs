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
                    token.Split(" ");
                    listTwo.Add(token);
                }
    
                foreach (var token in listTwo)
                {
                    listTwo.Remove(" ");
                }
             //change this loop like this
                for (int i =listTwo.Count-1 ; i >0 ; i--)
                {
                    Console.Write(listTwo[i]);
                }
            }
        }
    }
