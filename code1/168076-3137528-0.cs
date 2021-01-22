    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBindAttribute<T> : Attribute
    {
        public string ColumnName { get; set; }
        public object DefaultUntypedValue 
        {
            get { return DefaultTypedValue; }
        }
    
        public T DefaultValue { get; set; }
    }
    
    public class ColumnBindInt32Attribute: ColumnBindAttribute<int> {}
    
    [ColumnBindInt32(ColumnName = "Category", DefaultValue = 100)]
    public int CategoryId { get; set; }
