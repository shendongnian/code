    private static IEnumerable<string> GetAllMatches(char[] chars, int length)
    {
        int[] indexes = new int[length];
        char[] current = new char[length];
        for (int i=0; i < length; i++)
        {
            current[i] = chars[0];
        }
        do
            {
                yield return new string(current);
            }
            while (Increment(indexes, current, chars));
    }
    
    private static bool Increment(int[] indexes, char[] current, char[] chars)
    {
        int position = indexes.Length-1;
    
        while (position >= 0)
        {
            indexes[position]++;
            if (indexes[position] < chars.Length)
            {
                 current[position] = chars[indexes[position]];
                 return true;
            }
            indexes[position] = 0;
            current[position] = chars[0];
            position--;
        }
        return false;
    }
