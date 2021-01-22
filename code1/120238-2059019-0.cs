    public interface IPreviousInstance<T>
    {
        T PreviousInstance { get; set; }
    }
    public class DataClass : IPreviousInstance<DataClass>
    {
        public DataClass PreviousInstance { get; set; }
        public bool ABoolProperty { get; set; }
    }
    public class DerivedDataClass : DataClass, IPreviousInstance<DerivedDataClass>
    {
        public new DerivedDataClass PreviousInstance { get; set; }
        public string AStringProperty { get; set; }
    }
