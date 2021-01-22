    public static class EnumExtensions
    {
        /// <summary>
        /// Gets all items for an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }
        /// <summary>
        /// Gets all items for an enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>() where T : struct
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }
        /// <summary>
        /// Gets all combined items from an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <example>
        /// Displays ValueA and ValueB.
        /// <code>
        /// EnumExample dummy = EnumExample.Combi;
        /// foreach (var item in dummy.GetAllSelectedItems<EnumExample>())
        /// {
        ///    Console.WriteLine(item);
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value)
        {
            int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                int itemAsInt = Convert.ToInt32(item, CultureInfo.InvariantCulture);
                if (itemAsInt == (valueAsInt & itemAsInt))
                {
                    yield return (T)item;
                }
            }
        }
        /// <summary>
        /// Determines whether the enum value contains a specific value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     <c>true</c> if value contains the specified value; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code>
        /// EnumExample dummy = EnumExample.Combi;
        /// if (dummy.Contains<EnumExample>(EnumExample.ValueA))
        /// {
        ///     Console.WriteLine("dummy contains EnumExample.ValueA");
        /// }
        /// </code>
        /// </example>
        public static bool Contains<T>(this Enum value, T request)
        {
            int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);
            int requestAsInt = Convert.ToInt32(request, CultureInfo.InvariantCulture);
            if (requestAsInt == (valueAsInt & requestAsInt))
            {
                return true;
            }
            return false;
        }
    }
