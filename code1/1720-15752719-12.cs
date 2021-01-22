    public const MyEnum MYENUM_MINIMUM = MyEnum.One;
    public const MyEnum MYENUM_MAXIMUM = MyEnum.Four;
    
    public enum MyEnum
    {
        One,
        Two,
        Three,
        Four
    };
    
    public static MyEnum Validate(MyEnum value)
    {
        if (value < MYENUM_MINIMUM) { return MYENUM_MINIMUM; }
        if (value > MYENUM_MAXIMUM) { return MYENUM_MAXIMUM; }
        return value;
    }
