    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace SamplePrograme
    {
        public class Program
        {
            public enum Suit : int
            {
                Spades = 0,
                Hearts = 1,
                Clubs = 2,
                Diamonds = 3
            }
    
            public static void Main(string[] args)
            {
                //from string
                Console.WriteLine((Suit) Enum.Parse(typeof(Suit), "Clubs"));
                
                //from int
                Console.WriteLine((Suit)1);
                
                //From number you can also
                Console.WriteLine((Suit)Enum.ToObject(typeof(Suit) ,1));
            }
        }
    }
