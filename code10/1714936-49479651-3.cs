    public class BaseClass
    {
    }
    public interface IHasDerivedProperties
    {
        string Property1 { get; set; }
        string Property2 { get; set; }
    }
    public class DerivedClass : BaseClass, IHasDerivedProperties
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    public class NewDerivedClass : BaseClass, IHasDerivedProperties
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
