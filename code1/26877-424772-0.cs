    [TypeConverter(typeof(CustomEnumTypeConverter(typeof(MyEnum))]
    public enum MyEnum
    {
      // The custom type converter will use the description attribute
      [Description("A custom description")]
      ValueWithCustomDescription,
      // This will be exposed exactly.
      Exact
    }
