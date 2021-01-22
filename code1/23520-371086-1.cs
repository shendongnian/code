        static void Main(string[] args)
        {
            string[] words = "This is as easy as it looks".Split(' ');
            // Passing WriteLine as the action
            Array.ForEach(words, Console.WriteLine);         
        }
