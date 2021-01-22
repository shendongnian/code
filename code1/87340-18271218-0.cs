    public static class EnumUtil
    {
        public static IEnumerable<TEnum> GetAllValues<TEnum>() 
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }   
    }
