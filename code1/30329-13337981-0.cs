        /// <summary>
        /// Gets the value of the <see cref="T:System.ComponentModel.DescriptionAttribute"/> on an enum.  
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="enumerationValue">A value of type <see cref="T:System.Enum"/></param>
        /// <returns>If the enum has a Description attribute, this method returns the description.  Otherwise it just calls ToString() on the enum.</returns>
        /// <remarks>Based on http://stackoverflow.com/questions/479410/enum-tostring/479417#479417 </remarks>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }
            // Tries to find a DescriptionAttribute for a potential friendly name for the enum
            return (type.GetMember(enumerationValue.ToString())
                    .SelectMany(mi => mi.GetCustomAttributes<DescriptionAttribute>(false),
                        (mi, ca) => ca.Description))
                   .FirstOrDefault() ?? enumerationValue.ToString();
        }
