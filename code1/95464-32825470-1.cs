    public static bool IsEqualTo<T>(this IList<T> list1, IList<T> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }
        foreach (var item in list1)
        {
            int index = -1;
            for (int x = 0; x < list2.Count; x++)
            {
                if (list2[x].Equals(item))
                {
                    index = x;
                }
            }
    
            if (index > -1)
            {
                list2.RemoveAt(index);
            }
            else
            {
                return false;
            }
        }
    
        return !list2.Any();
    }
