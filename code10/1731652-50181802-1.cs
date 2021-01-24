    public struct MyStruct
    {
        public int One;
        public int Two;
        public int Three;
    }
    
    public class MyEditableClass : Control
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public MyStruct MyProperty { get; set; } = new MyStruct();
    }
