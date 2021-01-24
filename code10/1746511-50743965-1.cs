    // Uses a < algorithm, so "E", "E" is false
    public static bool IsSorted(IEnumerable<string> enu)
    {
        // Note that we have a +1 in the IndexOf to balance the -1 here
        int lastIndex = -1;
        foreach (string str in enu)
        {
            // Start searching from the last index found + 1
            int index = list1.IndexOf(str, lastIndex + 1);
            // index == -1 means not found
            if (index == -1)
            {
                return false;
            }
            lastIndex = index;
        }
        return true;
    }
