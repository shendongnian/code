    public static class EnumHelper
    {
        // Get the Name value of the Display attribute if the   
        // enum has one, otherwise use the value converted to title case.  
        public static string GetDisplayName<TEnum>(this TEnum value)
            where TEnum : struct, IConvertible
        {
            var attr = value.GetAttributeOfType<TEnum, DisplayAttribute>();
            return attr == null ? value.ToString().ToSpacedTitleCase() : attr.Name;
        }
        // Get the ShortName value of the Display attribute if the   
        // enum has one, otherwise use the value converted to title case.  
        public static string GetDisplayShortName<TEnum>(this TEnum value)
            where TEnum : struct, IConvertible
        {
            var attr = value.GetAttributeOfType<TEnum, DisplayAttribute>();
            return attr == null ? value.ToString().ToSpacedTitleCase() : attr.ShortName;
        }
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="TEnum">The enum type</typeparam>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="value">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        private static T GetAttributeOfType<TEnum, T>(this TEnum value)
            where TEnum : struct, IConvertible
            where T : Attribute
        {
            return value.GetType()
                        .GetMember(value.ToString())
                        .First()
                        .GetCustomAttributes(false)
                        .OfType<T>()
                        .LastOrDefault();
        }
    }
