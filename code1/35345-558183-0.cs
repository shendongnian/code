    static void Main(string[] args)
    {
        object foo = null;
        object x = "something";
        Console.WriteLine(foo.NullToValue(x));
    }
    public static class ObjectExtensions
    {
        public static object NullToValue(this object obj, object value)
        {
            return obj != null ? obj : value;
        }
    }
