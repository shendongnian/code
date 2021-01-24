    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Game game = new Game();
                if (game.CheckAnswer())
                {
                    Console.WriteLine("true");
                }
                else if (!game.CheckAnswer())
                {
                    Console.WriteLine("false");
                }                
            }            
        }
    }
    
    class Word
    {
        public static string GetWord()
        {
            string[] words = new string[5] { "alpha", "bravo", "charlie", "delta", "echo" };
            Random random = new Random();
            return words[random.Next(5)];
        }
        public char[] correctAnswer = GetWord().ToCharArray();
    }
    
    class Game
    {
        static char guessLetter;
        static List<char> correctGuesses = new List<char>();
        static List<char> incorrectGuesses = new List<char>();
        Word word = new Word();
    
        public bool CheckAnswer()
        {
            guessLetter = Console.ReadKey().KeyChar;
            
            if (word.correctAnswer.Contains(guessLetter))
            {
                Console.WriteLine();
                return true;
            }
            Console.WriteLine();
            return false;
        }    
    }
