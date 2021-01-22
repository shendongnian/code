    public class Example
    {
    	public static void Foo<T>(int ID) { }
    	public static void Foo<T, U>(int ID) { }
    	public static void Foo<T>(string ID) { }
    	public static string Foo<T, U>(int intID, string ID) { return ID; }
    }
