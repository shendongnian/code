    static void Main()
    {
        string[] data = { "A", "B", "C", "D", "E" };
        WalkSubSequences(data, 3);
    }
    public static void WalkSubSequences<T>(IEnumerable<T> data, int sequenceLength)
    {
        T[] selected = new T[sequenceLength];
        WalkSubSequences(data.ToArray(), selected, 0, sequenceLength);
    }
    private static void WalkSubSequences<T>(T[] data, T[] selected,
        int startIndex, int sequenceLength)
    {
        for (int i = startIndex; i + sequenceLength <= data.Length; i++)
        {
            selected[selected.Length - sequenceLength] = data[i];
            if (sequenceLength == 1)
            {
                ShowResult(selected);
            }
            else
            {
                WalkSubSequences(data, selected, i + 1, sequenceLength - 1);
            }
        }
    }
    private static void ShowResult<T>(T[] selected)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(selected[0]);
        for (int j = 1; j < selected.Length; j++)
        {
            sb.Append(';').Append(selected[j]);
        }
        Console.WriteLine(sb.ToString());
    }
