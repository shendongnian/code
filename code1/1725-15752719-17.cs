    public static MyEnum Clamp(MyEnum value)
    {
        if (value < MYENUM_MINIMUM) { return MYENUM_MINIMUM; }
        if (value > MYENUM_MAXIMUM) { return MYENUM_MAXIMUM; }
        return value;
    }
