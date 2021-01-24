    public static IEnumerable<T> RandomlySelectedItems<T>(IEnumerable<T> sequence, int count, int sequenceLength, Random rng)
    {
        int available = sequenceLength;
        int remaining = count;
        using (var iterator = sequence.GetEnumerator())
        {
            for (int current = 0; current < sequenceLength; ++current)
            {
                iterator.MoveNext();
                if (rng.NextDouble() < remaining / (double)available)
                {
                    yield return iterator.Current;
                    --remaining;
                }
                --available;
            }
        }
    }
