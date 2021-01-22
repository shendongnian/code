    class ExampleClass
    {
        public ExampleClass()
        {
            string exampleString = "there is a cat";
            // Split string on spaces. This will separate all the words in a string
            string[] words = exampleString.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);
                // there
                // is
                // a
                // cat
            }
        }
    }
