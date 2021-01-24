    public static class ItemExtensions
    {
        public static void Set(this ICollection<Item> items, Func<Item, bool> predicate, object value)
        {
            var item = items.FirstOrDefault(predicate);
            if (item != null)
                item.Value = value;
        }
    }
