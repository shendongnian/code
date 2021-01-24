    static public List<Difference> CalculateDifferences(string before, string after)
    {
        List<Difference> result = new List<Difference>();
        Queue<char> barriers = new Queue<char>();
    
        #region Preprocessing
        int index = 0;
        for (int i = 0; i < after.Length; i++)
        {
            // Look for the first match starting at index
            int match = before.IndexOf(after[i], index);
            if (match != -1)
            {
                barriers.Enqueue(after[i]);
                index = match + 1;
            }
        }
        #endregion
    
        #region Queue Processing
        index = 0;
        while (barriers.Any())
        {
            char barrier = barriers.Dequeue();
            // Get the offset to the barrier in both strings, 
            // ignoring the part that's already been handled
            int offsetBefore = before.IndexOf(barrier, index) - index;
            int offsetAfter = after.IndexOf(barrier, index) - index;
            // Remove prefix from 'before' string
            if (offsetBefore > 0)
            {
                RemoveChars(before.Substring(index, offsetBefore), result);
                before = before.Substring(offsetBefore);
            }
            // Insert prefix from 'after' string
            if (offsetAfter > 0)
            {
                string substring = after.Substring(index, offsetAfter);
                AddChars(substring, result);
                before = before.Insert(index, substring);
                index += substring.Length;
            }
            // Jump over the barrier
            KeepChar(barrier, result);
            index++;
        }
        #endregion
    
        #region Post Queue processing
        if (index < before.Length)
        {
            RemoveChars(before.Substring(index), result);
        }
        if (index < after.Length)
        {
            AddChars(after.Substring(index), result);
        }
        #endregion
    
        return result;
    }
    
    static private void KeepChar(char barrier, List<Difference> result)
    {
        result.Add(new Difference()
        {
            c = barrier,
            op = Operation.Equal
        });
    }
    
    static private void AddChars(string substring, List<Difference> result)
    {
        result.AddRange(substring.Select(x => new Difference()
        {
            c = x,
            op = Operation.Add
        }));
    }
    
    static private void RemoveChars(string substring, List<Difference> result)
    {
        result.AddRange(substring.Select(x => new Difference()
        {
            c = x,
            op = Operation.Remove
        }));
    }
