    public static class Tools
    {
        public static int[] FindIndex(this Array haystack, object needle)
        {
            if (haystack.Rank == 1)
                return new[] { Array.IndexOf(haystack, needle) };
            var set = haystack.OfType<object>().ToList();
            var found = set.IndexOf(needle);
            if (found == -1)
                throw new Exception("needle not found in set");
            var indexes = new int[haystack.Rank];
            var last = found;
            var lastLength = set.Count;
            for (var rank =0; rank < haystack.Rank; rank++)
            {
                lastLength = lastLength / haystack.GetLength(rank);
                var value = last / lastLength;
                last -= value * lastLength;
                indexes[rank] = value;
            }
            return indexes;
        }
    }
