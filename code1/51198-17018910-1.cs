        /// <summary>
        /// Converts an Enum to string by it's description. falls back to ToString
        /// </summary>
        /// <param name="enumVal">The enum val.</param>
        /// <returns></returns>
        public static string ToStringByDescription(this Enum enumVal)
        {
            EnumToStringUsingDescription inter = new EnumToStringUsingDescription();
            string str = inter.EnumToString(enumVal);
            return str;
        }
