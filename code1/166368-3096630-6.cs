    public static void Remove<T>(this IList list)
    {
        if(list != null)
        {
            var toRemove = list.Where(i => typeof(i) == typeof(T)).ToList();
            foreach(var item in toRemove)
                list.Remove(item);
        }
    }
