    public class ForeignKeyTypeAttribute : ForeignKeyAttribute
    {
        public ForeignKeyTypeAttribute(string name) : base(name)
        { }
        public ForeignKeyTypeAttribute(Type t) : base(t.GetType().Name)
        { }
    }
