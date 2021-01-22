        static void Main(string[] args)
        {
            string[] words = "This is as easy as it looks".Split(' ');
            Array.ForEach(words, Console.WriteLine); // Passing WriteLine as the action
        }
