    public class Setting
    {
    
        public string Name { get; set; }
        public object Value { get; protected set; }
    }
    
    public class Setting<T> : Setting
    {
        public new T Value { get { return (T)base.Value; } set { base.Value = value; } }
    
        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }
    }
