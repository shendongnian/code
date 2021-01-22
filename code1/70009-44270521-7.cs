    public int Example(MyEnum value)
    {
        switch(value.Name)
        {
            default: //case nameof(MyEnum.Bork):
                return 0;
            case nameof(MyEnum.Foo):
                return 1;
            case nameof(MyEnum.Bar):
                return 2;
            case nameof(MyEnum.Bas):
                return 3;
        }
    }
