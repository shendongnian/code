    /// <summary>
    /// Makes each first letter of a word uppercase. The rest will be lowercase
    /// </summary>
    /// <param name="Phrase"></param>
    /// <returns></returns>
    public static string FormatWordsWithFirstCapital(string Phrase)
    {
         MatchCollection Matches = Regex.Matches(Phrase, "\\b\\w");
         Phrase = Phrase.ToLower();
         foreach (Match Match in Matches)
             Phrase = Phrase.Remove(Match.Index, 1).Insert(Match.Index, Match.Value.ToUpper());
    
         return Phrase;
    }
