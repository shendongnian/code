    public static Dictionary<string, int> GetObjectCount(List<string> items)
    {
        // Dictionary object to return
        var keysAndCount = new Dictionary<string, int>();
        // Iterate your string values
        foreach(string s in items)
        {
            // Check if dictionary contains the key, if so, add to count
            if (keysAndCount.ContainsKey(s))
            {
                keysAndCount[s]++;
            }
            else
            {
                // Add key to dictionary with initial count of 1
                keysAndCount.Add(s, 1);
            }
       }
       return keysAndCount;
    }
