    string Source = "The quick brown fox jumps over the lazy dog.\r\nThe quick brown fox jumps over the lazy dog.";
    string[] ReplaceAdjectives = { "quick", "lazy" };
    string[] ReplaceNouns = { "fox", "dog" };
    
    bool GuaranteeMatch = true;
    string[] SourceWords = Source.Split(' ');
    string result = "";
    Random R = new Random();
    for (int i = 0; i < SourceWords.Length; i++)
    {
        if (GuaranteeMatch)
        {
            int I = R.Next(0, Adjectives.Length) //Adjectives and Nouns have the same Length. This is a requirement for this method to work.
            if (ReplaceAdjectives.Contains(SourceWords[i]))
                result += " " + GetMatchingWord(Context.Adjective, I);
            else if (ReplaceNouns.Contains(SourceWords[i]))
                result += " " + GetMatchingWord(Context.Noun, I);
            else
                result += " " + SourceWords[i];
        }
        else
        {
            if (ReplaceAdjectives.Contains(SourceWords[i]))
                result += " " + GetRandomWord(Context.Adjective);
            else if (ReplaceNouns.Contains(SourceWords[i]))
                result += " " + GetRandomWord(Context.Noun);
            else
                result += " " + SourceWords[i];
        }
    }
    result = result.Trim() //Remove white spaces at the begining and end of the string.
