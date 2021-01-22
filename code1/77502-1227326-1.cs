    static IEnumerable<int> GetSequence(int fromValue, int toValue)
    {
        if (toValue >= fromValue)
        {
            for (int i = fromValue; i <= toValue; i++)
            {
                yield return i;
            }
        }
        else
        {
            for (int i = fromValue; i >= toValue; i--)
            {
                yield return i;
            }
        }
    }
