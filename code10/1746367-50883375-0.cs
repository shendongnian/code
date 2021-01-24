    class Class1
    {
        [CustomAttr("prop Name: " + nameof(MyProperty))]
        public int MyProperty { get; set; }
    }
    public class CustomAttr : Attribute
    {
        public CustomAttr(string test)
        {
        }
    }
