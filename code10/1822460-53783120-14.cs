    public class RootObject
    {
        public FirstObject FirstObject { get; set; }
    }
    public class FirstObject
    {
        public NestedObject NestedObject { get; set; }
        public List<OtherObject> OtherObject { get; set; }
    }
    public class NestedObject
    {
        public string AttributeString { get; set; }
        public string AttributeNumeric { get; set; }
    }
    public class OtherObject
    {
        public string ArrayVal { get; set; }  // using string instead of int here
    }
