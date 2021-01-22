    public static class ExtensionMethods
    {
        public static int IndexOfSequence<T>(this IEnumerable<T> source, IEnumerable<T> sequence)
        {
            return source.IndexOfSequence(sequence, EqualityComparer<T>.Default);
        }
        public static int IndexOfSequence<T>(this IEnumerable<T> source, IEnumerable<T> sequence, IEqualityComparer<T> comparer)
        {
            var seq = sequence.ToArray();
            
            int p = 0; // current position in source sequence
            int i = 0; // current position in searched sequence
            var prospects = new List<int>(); // list of prospective matches
            foreach (var item in source)
            {
                // Remove bad prospective matches
                prospects.RemoveAll(k => !comparer.Equals(item, seq[p - k]));
                // Is it the start of a prospective match ?
                if (comparer.Equals(item, seq[0]))
                {
                    prospects.Add(p);
                }
                // Does current character continues partial match ?
                if (comparer.Equals(item, seq[i]))
                {
                    i++;
                    // Do we have a complete match ?
                    if (i == seq.Length)
                    {
                        // Bingo !
                        return p - seq.Length + 1;
                    }
                }
                else // Mismatch
                {
                    // Do we have prospective matches to fall back to ?
                    if (prospects.Count > 0)
                    {
                        // Yes, use the first one
                        int k = prospects[0];
                        i = p - k + 1;
                    }
                    else
                    {
                        // No, start from beginning of searched sequence
                        i = 0;
                    }
                }
                p++;
            }
            // No match
            return -1;
        }
    }
