    using System;
    using System.Collections.Generic;
    class MainClass {
        public static void Main (string[] args) {
            var word = "Tomato";
            var input = "t";
            var letter = input.ToLower()[0];
            var indices = new List<int>();
            for(var i = 0; i < word.Length; i++)
                if (word.ToLower()[i] == letter)
                    indices.Add(i);
            Console.WriteLine($"Secret word: {word}");
            Console.WriteLine($"User guess: {input}");
            Console.WriteLine($"Found at {String.Join(", ", indices)}");
        }
    }
