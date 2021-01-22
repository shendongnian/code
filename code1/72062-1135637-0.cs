    private static bool CountsAreEqual(ICollection[] lists)
    {
        int previousCount = lists[0].Count;
        for (int i = 1; i < lists.Count; i++)
        {
            if (lists[i].Count != previousCount)
            {
                return false;
            }
        }
        return true;
    }
