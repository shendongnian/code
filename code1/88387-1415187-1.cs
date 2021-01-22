    public enum MyEnum
    {
        [Description("Description for Foo")]
        Foo,
        [Description("Description for Bar")]
        Bar
    }
    
    MyEnum x = MyEnum.Foo;
    string description = x.GetDescription();
