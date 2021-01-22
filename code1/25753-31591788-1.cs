    PropertyInfo pi; // set to some property info
    object defaultValue = pi.PropertyType.ToDefault();
    public struct MyTypeValue { public int SomeIntProperty { get; set; }
    var reflectedType = typeof(MyTypeValue);
    object defaultValue2 = reflectedType.ToDefault();
