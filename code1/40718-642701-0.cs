    public void SomeMethod(MyEnum myEnum)
    {
        MyEnum? nextMyEnum = myEnum.Next();
    
        if (nextMyEnum.HasValue)
        {
            ...
        }
    }
    public static MyEnum? Next(this MyEnum myEnum)
    {
        switch (myEnum)
        {
            case MyEnum.A:
                return MyEnum.B;
            case MyEnum.B:
                return MyEnum.C;
            case MyEnum.C:
                return MyEnum.D;
            default:
                return null;
        }
    }
    
