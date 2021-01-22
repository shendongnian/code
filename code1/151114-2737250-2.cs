    public static IEnumerable<IEnumerable<int>> AllSequences(int start, int end,
        int size)
    {
        return size <= 0 ? new[] { new int[0] } :
               from i in Enumerable.Range(start, end - size - start + 2)
               from seq in AllSequences(i + 1, end, size - 1)
               select Enumerable.Concat(new[] { i }, seq);
    }
