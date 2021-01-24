    public static class ListExtensions
    {
        public static void AddOrIgnore(this List list, object item)
        {
            if (item == null) return;
            list.Add(item);
        }
    }
