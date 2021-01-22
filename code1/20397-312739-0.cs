    public static IEnumerable<String> GetWords()
    {
        for (Char c1 = 'A'; c1 <= 'Z'; c1++)
        {
            for (Char c2 = 'A'; c2 <= 'Z'; c2++)
            {
                for (Char c3 = 'A'; c3 <= 'Z'; c3++)
                {
                    for (Char c4 = 'A'; c4 <= 'Z'; c4++)
                    {
                        yield return "" + c1 + c2 + c3 + c4;
                    }
                }
            }
        }
    }
