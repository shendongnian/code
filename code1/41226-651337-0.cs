    [XmlInclude(typeof(DerivedClass))]
    public abstract class BaseClass
    {
        public abstract bool Property { get; set; }
    }
    public class DerivedClass : BaseClass
    {
        public override bool Property { get; set; }
    }
