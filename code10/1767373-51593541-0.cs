    public static SortedDictionary<char, int> Count(string stringToCount)
    {
        // Create a new empty SortedDictionary
         SortedDictionary<char, int> characterCount = new SortedDictionary<char, int>();
        // Loop through each character in stringToCount and see if SortedDictionary contains a key equal to this character (it doesn't as dictionary is empty).
        foreach (var character in stringToCount)
         {
             int counter = 0;
             characterCount.TryGetValue(character, out counter);
             characterCount[character] = counter +1;
         }
         return characterCount;
    }
