    public static List<int> Reduce(List<int> input, int targetItemsCount)
    {
        while (input.Count() >= targetItemsCount)
        {
            var nIndex = input.Count() / targetItemsCount;
            input = input.Where((x, i) => i % nIndex == 0).ToList();
        }
        return input;
    }
