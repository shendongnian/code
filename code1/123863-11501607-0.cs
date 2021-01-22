        public static class DataItemExtensions
    {
             public static T As<T>(this IDataItemContainer repeater) where T : class
        {
            return (T)repeater.DataItem;
        }
        public static dynamic AsDynamic(this IDataItemContainer repeater)
        {
            return repeater.DataItem;
        }
    }
