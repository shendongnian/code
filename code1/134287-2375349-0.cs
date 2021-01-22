    public class Helper 
    {
    public static ValidateEntityAttribute(Type objectType, Enum objectEnum, object Value) 
    { 
    if(objectType.GetMethod("IsValid", BindingFlags.NonPublic).Invoke(null, BindingFlags.NonPublic, null, new object[{objectEnum, Value}], null))
    throw new Exception("Invalid entry");
    } 
    }
 
