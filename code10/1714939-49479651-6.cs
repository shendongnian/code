    public class BaseClass
    {
    }
    public abstract class IntermediateClass : BaseClass
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    public class DerivedClass : IntermediateClass 
    {
    }
    public class NewDerivedClass : IntermediateClass 
    {
    }
