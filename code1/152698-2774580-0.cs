    public int Count(IList list)
    {
       int count1 = list.Count; // Fine
       dynamic d = list;
       int count2 = list.Count; // Should work, right?
    }
