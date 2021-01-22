       string[] foo = "Mimi loves Toto and Tata hate Mimi so Toto killed Tata".Split(' ');
                HashSet<string> words = new HashSet<string>();
                foreach (string word in foo)
                {
                    if (char.IsUpper(word[0]))
                    {
                        words.Add(word);
                    }
                }
    
                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
