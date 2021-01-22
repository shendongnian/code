    public class GenericBaseClass<T>
    {
        public List<T> collection { get; set; }
    }
    
    public class GenericDerivedClass1 : GenericBaseClass<DerivedClass1>
    {
        // Here the collection property will be of type List<DerivedClass1>
    }
