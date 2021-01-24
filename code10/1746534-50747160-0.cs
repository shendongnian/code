    private static void DisplayMaskedWord(string word, List<char> lettersGuessed)
    {
        if (word == null)
        {
            Console.WriteLine();
        }
        else if (lettersGuessed == null)
        {
            Console.WriteLine(new string('-', word.Length));
        }
        else
        {
            Console.WriteLine(string.Join("", 
                word.Select(c => lettersGuessed.Contains(c) ? c : '-')));
        }
    }
