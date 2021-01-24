    public class GrandChild
    {
        public int IntegerValue { get; set; }
        public string StringValue { get; set; }
        public bool BooleanValue { get; set; }
        public DateTime DateTimeValue { get; set; }
    }
    public class Child
    {
        public GrandChild First { get; set; }
        public GrandChild Second { get; set; }
    }
    public class Parent
    {
        public Child Mother { get; set; }
        public Child Father { get; set; }
    }
