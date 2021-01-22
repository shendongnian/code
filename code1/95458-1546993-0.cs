    public static bool ListEquals<T>(IList<T> list1, IList<T> list2) {
        if (list1.Count != list2.Count)
            return false;
        for (int i = 0; i < list1.Count; i++)
            if (!list1[i].Equals(list2[i]))
                return false;
        return true;
    }
