typeof(Translation).ToValueList<int>();
        /// <summary>
        /// If an enum MyEnum is { a = 3, b = 5, c = 12 } then
        /// typeof(MyEnum).ToValueList<<int>>() will return [3, 5, 12]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumType"></param>
        /// <returns>List of values defined for enum constants</returns>
        public static List<T> ToValueList<T>(this Type enumType)
        {
            return Enum.GetNames(enumType)
                .Select(x => (T)Enum.Parse(enumType, x))
                .ToList();
        }
