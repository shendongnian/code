    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            //dont call the method in if else save the result in a var first maybe
            Console.WriteLine(game.CheckAnswer());
        }   
    }
    
    class Word
    {
        public static string GetWord()
        {
            string[] words = new string[5]{"alpha", "bravo", "charlie", "delta", "echo"};
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
            guessLetter = Convert.ToChar(Console.ReadLine());
            
            //you can return the result directly
            return word.correctAnswer.Contains(guessLetter);
        }
    }
