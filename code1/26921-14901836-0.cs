    public enum Color 
    { Red = 1, Green = 2, Blue = 3}
    
    public static EnumUtils 
    {
       public static string GetEnumResourceString(object enumValue)
        {
            Type enumType = enumValue.GetType();
            string value = Enum.GetName(enumValue.GetType(), enumValue);
            string resourceKey = String.Format("{0}_{1}", enumType.Name, value);
            string result = Resources.Enums.ResourceManager.GetString(resourceKey);
            if (string.IsNullOrEmpty(result))
            {
                result = String.Format("{0}", value);
            }
            return result;
        }
    }
