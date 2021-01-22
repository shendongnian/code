    public int Method(MyEnum myEnum)
    {
        switch (myEnum)
        {
            case MyEnum.Value1: return 1;
            case MyEnum.Value2: return 2;
            case MyEnum.Value3: return 3;
            default: return 0;
        }
    }
