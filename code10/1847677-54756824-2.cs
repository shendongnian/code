    private static IEnumerable<T> Sort<T>(IEnumerable<T> input) where T : IComparable<T>
    {
        var results = input.ToList();
        for (int counter = 0; counter < results.Count; counter++)
        {
            for (int index = 0; index < results.Count - 1; index++)
            {
                if (results[index].CompareTo(results[index + 1]) > 0)
                {
                    var temp = results[index + 1];
                    results[index + 1] = results[index];
                    results[index] = temp;
                }
            }
        }
        return results;
    }
