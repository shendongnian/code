    class CountValueComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            DictionaryEntry left = (DictionaryEntry)x;
            DictionaryEntry right = (DictionaryEntry)y;
            return ((int)left.Value).CompareTo((int)right.Value);
        }
    }
    Hashtable counts = new Hashtable();
    foreach(String value in arrName)
    {
        if (counts.ContainsKey(value))
        {
            int valueCount = (int)counts[value];
            ++valueCount;
            counts[value] = valueCount;
        }
        else
        {
            counts[value] = 1;
        }
    }
    
    DictionaryEntry[] sorted = new DictionaryEntry[counts.Count];
    counts.CopyTo(sorted, 0);
    Array.Sort(sorted, new CountValueComparer());
    foreach (DictionaryEntry entry in sorted)
    {
        Console.Writeline("Name: {0}; Count: {1}", entry.Key, entry.Value);
    }
