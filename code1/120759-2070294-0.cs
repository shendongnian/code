    [EdmScalarProperty]
    public int EnumPropInteger {get;set}
    public MyEnum EnumProp
    {
        get { return (MyEnum) EnumPropInteger; }
        set { EnumPropInteger = (int)value; }
    }
