    public class DataClass<T> : BaseClass<T>
    {
        public bool ABoolProperty { get; set; }
    }
----------
    public class DataClass : DataClass<DataClass>  
    {
    }
