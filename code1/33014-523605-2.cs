    static void Main()
    {
        foreach (string value in GetCombinations(
            "A", "B", "C", "D", "E", "F", "G", "H"))
        {
            Console.WriteLine(value);
        }
    }
    static IEnumerable<string> GetCombinations(params string[] tokens)
    {
        ulong max = (ulong) 1 << tokens.Length;
        StringBuilder builder = new StringBuilder();
        // test all bitwise combinations
        for (ulong value = 0; value < max; value++)
        {
            builder.Length = 0;
            ulong tmp = value;
            // include the tokens for the set bits
            for (int i = 0; i < tokens.Length; i++)
            {
                if ((tmp & (ulong)1) == 1) builder.Append(tokens[i]);
                tmp >>= 1;
            }
            yield return builder.ToString();
        }
    }
