    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBindAttribute: Attribute
    {
        public string ColumnName { get; set; }
        public object DefaultUntypedValue 
        {
            get;
            protected set;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBindGenericAttribute<T> : ColumnBindAttribute
    {    
        public T DefaultValue 
        { 
            get { return (T)DefaultUntypedValue; }
            set { DefaultUntypedValue = value; }
        }
    }
    [AttributeUsage(AttributeTargets.Property)]    
    public class ColumnBindInt32Attribute: ColumnBindGenericAttribute<int> {}
    
    [ColumnBindInt32(ColumnName = "Category", DefaultValue = 100)]
    public int CategoryId { get; set; }
