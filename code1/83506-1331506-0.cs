        public class EnumUtils
        {
        /// <summary>
        ///     Reads and returns the value of the Description Attribute of an enumeration value.
        /// </summary>
        /// <param name="value">The enumeration value whose Description attribute you wish to have returned.</param>
        /// <returns>The string value portion of the Description attribute.</returns>
        public static string StringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        /// <summary>
        ///     Returns the Enumeration value that has a given Description attribute.
        /// </summary>
        /// <param name="value">The Description attribute value.</param>
        /// <param name="enumType">The type of enumeration in which to search.</param>
        /// <returns>The enumeration value that matches the Description value provided.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified Description value is not found with in the provided Enumeration Type.</exception>
        public static object EnumValueOf(string value, Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names)
            {
                if (StringValueOf((Enum)Enum.Parse(enumType, name)).Equals(value))
                {
                    return Enum.Parse(enumType, name);
                }
            }
            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
