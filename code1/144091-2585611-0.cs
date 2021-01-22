    static void Main(string[] args)
    {
        List<string> ints = new List<string> { "3", "1", "", "5", "", "2" };
        CustomIntSort(ints, (x, y) => int.Parse(x) - int.Parse(y)); // Ascending
        ints.ForEach(i => Console.WriteLine("[{0}]", i));
        CustomIntSort(ints, (x, y) => int.Parse(y) - int.Parse(x)); // Descending
        ints.ForEach(i => Console.WriteLine("[{0}]", i)); 
    }
    private static void CustomIntSort(List<string> ints, Comparison<string> Comparer)
    {
        int emptySlots = CountAndRemove(ints);
        ints.Sort(Comparer);
        for (int i = 0; i < emptySlots; i++)
            ints.Add("");
    }
    private static int CountAndRemove(List<string> ints)
    {
        int emptySlots = 0;
        int i = 0;
        while (i < ints.Count)
        {
            if (string.IsNullOrEmpty(ints[i]))
            {
                emptySlots++;
                ints.RemoveAt(i);
            }
            else
                i++;
        }
        return emptySlots;
    }
