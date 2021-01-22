    public interface IMyObject
    {
        IEnumerable<string> GetFieldNames();
        IEnumerable<Type> GetFieldTypes();
    
        //i would add this property, then you can bind directly to it.
        //basically it is a collection indexer, indexed by string
        object this[String name] { get; set; }
    
        object GetField(string name);
        void SetField(string name, object value);
    }
