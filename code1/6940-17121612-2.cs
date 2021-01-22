    public static class EnumExtensions
    {
        /// <summary>
        /// Gets all items for an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>(this T value) where T : Enum
        {
            return (T[])Enum.GetValues(typeof (T));
        }
    }
