    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace BackwardsTest
    {
        class PrintBackwards
        {
            public static void print(string param)
            {
                if (param == null)
                    Console.WriteLine("string is null");
                List<char> list = new List<char>();
                string returned = null;
                foreach(char d in param)
                {
                    list.Add(d);
                }
                for(int i = list.Count(); i > 0; i--)
                {
                    returned = returned + list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                }
                Console.WriteLine(returned);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string test = "I want to print backwards";
                PrintBackwards.print(test);
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
