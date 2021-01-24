    public static class ItemExtensions
    {
        static Dictionary<Item, Action<Item>>
            methods = new Dictionary<Item, Action<Item>>()
            {
                { new Item(Shape.any, Color.blue, Material.glass), x=> { /*do something*/ } }
            };
        public static bool TryApply(this Item item)
        {
            if (methods.TryGetValue(item, out var action))
            {
                action(item);
                return true;
            }
            return false;
        }
