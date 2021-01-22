    using System;
    using System.Collections.Generic;
    
    public class Test
    {
        static void Main(string[] args)
        {
            var actions = new List<Action<string>> {
                First, Second
            };
            
            foreach (var action in actions)
            {
                foreach (string arg in args)
                {
                    action(arg);
                }
            }
        }
        
        static void First(string x)
        {
            Console.WriteLine("First: " + x);
        }
    
        static void Second(string x)
        {
            Console.WriteLine("Second: " + x);
        }
    }
