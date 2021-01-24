    static void Main(string[] args)
    {
        string longText = @"your sentence comes here";
        foreach (var character in CharacterCount.Count(longText))
        {
            if(character.Value>1)
               Console.WriteLine("{0} - {1}", character.Key, character.Value);
        }    
    }
    class CharacterCount
    {
        public static SortedDictionary<char, ulong> Count(string stringToCount)
        {
            SortedDictionary<char, ulong> characterCount = new SortedDictionary<char, ulong>();
            foreach (var character in stringToCount)
            {
                if (!characterCount.ContainsKey(character))
                    characterCount.Add(character, 1);
                else
                    characterCount[character]++;
            }
            return characterCount;
        }   
    }  
