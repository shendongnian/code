    public abstract class Enums<Temp> where Temp : class {
    	public static TEnum Parse<TEnum>(string name) where TEnum : struct, Temp {
    		return (TEnum)Enum.Parse(typeof(TEnum), name); 
    	}
    }
    public abstract class Enums : Enums<Enum> { }
    Enums.Parse<DateTimeKind>("Local")
