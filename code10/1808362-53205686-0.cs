    static void Main(string[] args)
    {
        MyType myType;
        myType.value = 1;
        MyEnum myEnum = (MyEnum) myType;
        Console.WriteLine(myEnum);
        Console.ReadLine();
    }
    enum MyEnum : int
    {
        a = 0,
        b = 1
    }
    struct MyType
    {
        public int value;
        public static explicit operator MyEnum(MyType myType)
        {
            return (MyEnum)myType.value;
        }
    }
