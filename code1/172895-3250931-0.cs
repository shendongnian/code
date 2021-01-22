    public static bool SequenceEquals<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2)
    {
        foreach (var pair in Enumerable.Zip(seq1, seq2)
        {
            if (!pair.Item1.Equals(pair.Item2))
                return;
        }
        return false;
    }
