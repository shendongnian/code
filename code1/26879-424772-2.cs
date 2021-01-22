    [TypeConverter(typeof(CustomEnumTypeConverter<MyEnum>))]
    public enum MyEnum
    {
        // The custom type converter will use the description attribute
        [Description("A custom description")]
        ValueWithCustomDescription,
       // This will be exposed exactly.
       Exact
    }
