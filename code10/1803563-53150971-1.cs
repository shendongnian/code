    /// <summary>
    /// Helper class for enum types 
    /// </summary>
    public static class myEnumExtender
    {
        /// <summary>
        /// Get the value of a Description attribute assigned to an enum element 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Description(this Enum value)
        {
            var fieldInfo = value
                .GetType()
                .GetField(value.ToString());
            var attributes = fieldInfo
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .OfType<DescriptionAttribute>()
                .ToList();
            return attributes.Any() ? attributes.First().Description : value.ToString();
        }
        /// <summary>
        /// Gets all the elements of an enum type 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <remarks>
        /// c# doesn't support where T: Enum - this is the best compromise
        /// </remarks>
        public static ReadOnlyCollection<T> GetValues<T>() 
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var itemType = typeof (T);
            if (!itemType.IsEnum)
                throw new ArgumentException($"Type '{itemType.Name}' is not an enum");
            var fields = itemType
                .GetFields()
                .Where(field => field.IsLiteral);
            return fields
                .Select(field => field.GetValue(itemType))
                .Cast<T>()
                .ToList()
                .AsReadOnly();
        }
        /// <summary>
        /// Generate a <see cref="myValueDisplayPair"/> list containing all elements of an enum type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortByDisplay"></param>
        public static ReadOnlyCollection<myValueDisplayPair<T>> MakeValueDisplayPairs<T>(bool sortByDisplay = false) 
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var itemType = typeof(T);
            if (!itemType.IsEnum)
                throw new ArgumentException($"Type '{itemType.Name}' is not an enum");
            var values = GetValues<T>();
            var result = values
                .Select(v => v.CreateValueDisplayPair())
                .ToList();
            if (sortByDisplay)
                result.Sort((p1, p2) => string.Compare(p1.Display, p2.Display, StringComparison.InvariantCultureIgnoreCase));
            return result.AsReadOnly();
        }
    }
