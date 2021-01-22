    public static bool IsEqualTo<T>(this IList<T> list1, IList<T> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }
        List<T> list3 = new List<T>();
        foreach (var item in list2)
        {
            list3.Add(item);
        }
        foreach (var item in list1)
        {
            int index = -1;
            for (int x = 0; x < list3.Count; x++)
            {
                if (list3[x].Equals(item))
                {
                    index = x;
                }
            }
    
            if (index > -1)
            {
                list3.RemoveAt(index);
            }
            else
            {
                return false;
            }
        }
    
        return !list3.Any();
    }
