    public static void Remove<T>(this IList list)
    {
        ArrayList deleteList = new ArrayList();
        foreach (var item in list)
            if (item.GetType() == typeof(T))
                deleteList.Add(item);
        for (int i = 0; i < deleteList.Count; i++)
            list.Remove(deleteList[i]);        
    }
