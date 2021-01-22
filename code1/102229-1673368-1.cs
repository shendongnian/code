    static bool IsSame<T>(IEnumerable<T> set1, IEnumerable<T> set2)
    {
        if (set1 == null && set2 == null)
            return true;
        if (set1 == null || set2 == null)
            return false;
        List<T> list1 = set1.ToList();
        List<T> list2 = set2.ToList();
        if (list1.Count != list2.Count)
            return false;
        list1.Sort();
        list2.Sort();
        for (int i = 0; i < list1.Count; i++)
        {
            if (!list1[i].Equals(list2[i]))
                return false;
        }
        return true;
    }
