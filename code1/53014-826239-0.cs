    [Flags]
    enum MyEnum {
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        D = 8
    }
    //...
    MyEnum a = MyEnum.B
    if((a & (MyEnum.B | MyEnum.C)) > 0)
        // do something
