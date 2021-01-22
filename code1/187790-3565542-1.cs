    public static string TruncateLongWords(this string sentence, int maximumWordLength)
    {
        var longWords = sentence.Split(' ').Where(w => w.Length > maximumWordLength);
    
        foreach (var longWord in longWords)
        {
            sentence = sentence.Replace(longWord, longWord.Substring(maximumWordLength));
        }
    
        return sentence;
    }
