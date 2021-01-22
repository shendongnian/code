    public static void Remove<T>(this IList list)
    {
        if(list != null)
        {
            var toRemove = list.OfType<T>().ToList();
    
            foreach(var item in toRemove)
                list.Remove(item);
        }
    }
