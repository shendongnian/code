    public abstract class EnumClassUtils<TClass>
    where TClass : class
    {
    
        public static TEnum Parse<TEnum>(string value)
        where TEnum : struct, TClass
        {
            return (TEnum) Enum.Parse(typeof(TEnum), value);
    	}
    
    }
    
    public class EnumUtils : EnumClassUtils<Enum>
    {
    }
