        /// <summary>
        /// Gets the value of the <see cref="T:System.ComponentModel.DescriptionAttribute"/> on an struct, including enums.  
        /// </summary>
        /// <typeparam name="T">The type of the struct.</typeparam>
        /// <param name="enumerationValue">A value of type <see cref="T:System.Enum"/></param>
        /// <returns>If the struct has a Description attribute, this method returns the description.  Otherwise it just calls ToString() on the struct.</returns>
        /// <remarks>Based on http://stackoverflow.com/questions/479410/enum-tostring/479417#479417, but useful for any struct.</remarks>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            return enumerationValue.GetType().GetMember(enumerationValue.ToString())
                    .SelectMany(mi => mi.GetCustomAttributes<DescriptionAttribute>(false),
                        (mi, ca) => ca.Description)
                    .FirstOrDefault() ?? enumerationValue.ToString();
        }   
