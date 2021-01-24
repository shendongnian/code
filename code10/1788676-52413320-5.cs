     public static class ItemExtensionsUsingValueTuple
     {
        static Dictionary<(Shape, Color, Material), Action<Item>>
            methods = new Dictionary<(Shape, Color, Material), Action<Item>>()
            {
                { (Shape.any, Color.blue, Material.glass), x=> { /*do something*/ } }
            };
        public static bool TryApply(this Item item)
        {
            if (methods.TryGetValue((item.ItemShape, item.ItemColor, item.ItemMaterial), out var action))
            {
                action(item);
                return true;
            }
            return false;
        }
    }
