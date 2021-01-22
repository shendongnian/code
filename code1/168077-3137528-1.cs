    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBindAttribute: Attribute
    {
        public string ColumnName { get; set; }
        public object DefaultUntypedValue 
        {
            get { return DefaultTypedValue; }
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBindGenericAttribute<T> : ColumnBindAttribute
    {    
        public T DefaultValue { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property)]    
    public class ColumnBindInt32Attribute: ColumnBindGenericAttribute<int> {}
    
    [ColumnBindInt32(ColumnName = "Category", DefaultValue = 100)]
    public int CategoryId { get; set; }
