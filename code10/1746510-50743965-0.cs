    static List<string> list1 = new List<string> { "E", "C", "B", "A" };
    // Uses a <= algorithm, so "E", "E" is true
    public static bool IsSorted(IEnumerable<string> enu)
    {
        // index of last letter used in list1
        int lastIndex = 0;
        foreach (string str in enu)
        {
            // Start searching from the last index found
            int index = list1.IndexOf(str, lastIndex);
            // index == -1 means not found
            if (index == -1)
            {
                return false;
            }
            lastIndex = index;
        }
        return true;
    }
