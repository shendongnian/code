    static public class EnumHelper<T>
    {
       static public T Parse(string value)
       {
           return (T)Enum.Parse(typeof(T), value);
       }
    }
