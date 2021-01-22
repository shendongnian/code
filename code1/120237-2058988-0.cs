    public abstract class AbstractDataClass<T> : BaseClass<T>
    { 
       public bool ABoolProperty { get; set; }
    }
    
    public class DataClass : AbstractDataClass<DataClass>
    {
    }
    
    public class DerivedClass : AbstractDataClass<DerivedClass>
    {
       public string AStringProperty { get; set; }
    }
