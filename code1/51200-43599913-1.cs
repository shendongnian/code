    public static class Utils
    {
        public static IEnumerable<EnumItem<T>> GetEnumValues<T>()
        {
            List<EnumItem<T>> result = new List<EnumItem<T>>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                result.Add(item);
            }
            return result;
        }
    }
