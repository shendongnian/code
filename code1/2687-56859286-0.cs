    public static class EnumHelper
    {
        public static T ToEnum<T>(dynamic value)
        {
            return (T)Enum.ToObject(typeof(T),
                     Convert.ChangeType(value, Enum.GetUnderlyingType(typeof(T))));
        }
    }
