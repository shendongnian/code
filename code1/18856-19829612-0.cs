    //an interface which means it can't have its own implementation. 
    //You might need to use extension methods on this interface for that.
    public interface ValidatesAttribute<T>
    {
        T Value { get; } //or whatever that is
        bool IsValid { get; } //etc
    }
    
    public class ValidatesStringAttribute : Attribute, ValidatesAttribute<string>
    {
        //...
    }
    public class ValidatesIntAttribute : Attribute, ValidatesAttribute<int>
    {
        //...
    }
    [ValidatesString]
    public static class StringValidation
    {
    
    }
    [ValidatesInt]
    public static class IntValidation
    {
    
    }
