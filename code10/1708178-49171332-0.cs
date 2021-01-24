      using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "Hellou1 Hellou2";
                int index = text.LastIndexOf(' ');
                text = text.Substring(0, index);
                Console.WriteLine(text);
    
            }
        }
    }
