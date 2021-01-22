    public static class ListExtension
    {
        public static void AddSort<T>(this List<T> list, T item)
        {
            list.Add(item);
            list.Sort();
        }
    }
