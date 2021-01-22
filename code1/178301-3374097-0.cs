    // helper method to break up into blocks lazily
    public static IEnumerable<ICollection<T>> SplitEnumerable<T>
        (IEnumerable<T> Sequence, int NbrPerBlock)
    {
        List<T> Group = new List<T>(NbrPerBlock);
        foreach (T value in Sequence)
        {
            Group.Add(value);
            if (Group.Count == NbrPerBlock)
            {
                yield return Group;
                Group = new List<T>(NbrPerBlock);
            }
        }
        if (Group.Any()) yield return Group; // flush out any remaining
    }
    // now it's trivial; if you want to make smaller files, just foreach
    // over this and write out the lines in each block to a new file
    public static IEnumerable<ICollection<string>> SplitFile(string filePath)
    {
        return File.ReadLines(filePath).SplitEnumerable(20000);
    }
