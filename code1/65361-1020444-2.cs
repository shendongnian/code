    public static bool IsSubsetOf(byte[] set, byte[] subset) {
        for(int i = 0; i < set.Length && i + subset.Length <= set.Length; ++i)
            if (set.Skip(i).Take(subset.Length).SequenceEqual(subset))
                return true;
        return false;
    }
