    private static void Main()
    {
        string word = "apple";
        // This stores the guessed characters, currently only a 'p'
        var guessedLetters = new List<char> {'p'};
        Console.WriteLine(GetMaskedWord(word, guessedLetters));
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
