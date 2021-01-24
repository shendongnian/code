    private struct Entry 
    {
        public int hashCode;    // Lower 31 bits of hash code, -1 if unused
        public int next;        // Index of next entry, -1 if last
        public TKey key;        // Key of entry
        public TValue value;    // Value of entry
    }
