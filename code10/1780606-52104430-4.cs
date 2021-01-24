    public abstract class BaseClass
    {
        public string Box1 { get; set; }
        public string Box2 { get; set; }
    }
    public class Class1 : BaseClass
    {
        public int AdditionalProp { get; set; }
    }
    public class Class2 : BaseClass
    {
        public double YetAnotherlProp { get; set; }
    }
    public class Class3 : BaseClass
    { }
    public class Class4 : BaseClass
    { }
