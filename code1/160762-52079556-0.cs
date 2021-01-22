    public static string RemoveAfter(this string value, string character)
        {
            int index = value.IndexOf(character);
            if (index > 0)
            {
                value = value.Substring(0, index);
            }
            return value;
        }
        public static string RemoveBefore(this string value, string character)
        {
            int index = value.IndexOf(character);
            if (index > 0)
            {
                value = value.Substring(index + 1);
            }
            return value;
        }
