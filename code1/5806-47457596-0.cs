    public static class EnumUtils
    {
        public static Enum GetEnumFromString(string value, Enum defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            foreach (Enum item in Enum.GetValues(defaultValue.GetType()))
            {
                if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
            }
            return defaultValue;
        }
    }
