    private enum MyEnum
    {
        Enum1 = 1, Enum2 = 2, Enum3 = 3, Enum4 = 4, Enum5 = 5, Enum6 = 6, 
        Enum7 = 7, Enum8 = 8, Enum9 = 9, Enum10 = 10
    }
    private static Object ParseEnum<T>(string s)
    {
        try
        {
            var o = Enum.Parse(typeof (T), s);
            return (T)o;
        }
        catch(ArgumentException)
        {
            return null;
        }
    }
    static void Main(string[] args)
    {
       Console.WriteLine(ParseEnum<MyEnum>("Enum11"));
       Console.WriteLine(ParseEnum<MyEnum>("Enum1"));
       Console.WriteLine(ParseEnum<MyEnum>("Enum6").GetType());
       Console.WriteLine(ParseEnum<MyEnum>("Enum10"));
    }
