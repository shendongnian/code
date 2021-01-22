    private static IEnumerable<int> ParseInt32s(IEnumerable<string> value)
    {
        foreach(var value in values)
        {
            int n;
            if(Int32.TryParse(value, out n))
            {
                yield return n;
            }
        }
    }
