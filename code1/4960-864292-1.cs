    public static class TypeHelper<T>
    {
        public static bool IsDefault(T val)
        {
            return (val == null || val.Equals(default(T)));
        }
    }
    static void Main(string[] args)
    {
        // value type
        Console.WriteLine(TypeHelper<int>.IsDefault(1)); //False
        Console.WriteLine(TypeHelper<int>.IsDefault(0)); // True
            
        // reference type
        Console.WriteLine(TypeHelper<string>.IsDefault("test")); //False
        Console.WriteLine(TypeHelper<string>.IsDefault(null)); //True //True
        Console.ReadKey();
    }
