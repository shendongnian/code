    public List<string> WordList (int stringLength, string inputWord)
    {
        List<string> wordList;
        List<byte> letterCounter;
        String word;
        char[] letters = inputWord.ToCharArray();
        
        for (int i = 0; i < stringLength; i++)
        {
            letterCounter.Add(0);
        }
    
        while (letterCounter[0] < 10)
        {
            for (int i = 0; i < stringLength; i++)
            {
                char letter = letters[letterCounter[i]];
                word = new string(word + letter);
            }
    
            wordList.Add(word);
            letterCounter[stringLength]++;
        
            for (int i = stringLength; i > 0; i--)
            {
                if (letterCounter[i] >= 10)
                    if (i > 0)
                        letterCounter [i - 1]++;
            }
        }
    
        return wordList;
    }
