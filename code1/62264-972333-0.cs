        /// <summary>
        /// Returns a generic list of all values for an enum.
        /// Taken from http://devlicio.us/blogs/joe_niland/archive/2006/10/10/Generic-Enum-to-List_3C00_T_3E00_-converter.aspx
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> EnumToList<T>()
        {
            Type enumType = typeof(T);
            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");
            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);
            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }
            return enumValList;
        }
