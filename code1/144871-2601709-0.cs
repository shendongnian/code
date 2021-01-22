    private static IList<T> pairSwitch<T>(IList<T> original)
    {
        List<T> results = new List<T>(original.Count);
        for (int i=0;i<original.Count-1;i+=2)  // Using -1 to make sure an odd number doesn't throw...
        {
            results.Add(original[i+1]);
            results.Add(original[i]);
        }
        return results;
    }
