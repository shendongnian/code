    public class JSGridVM
    {
        private Dictionary<Type, object> Tables = new Dictionary<Type, object>();
    
        public JSGridVM AddJSTable<RowType>()
        {
            Tables.Add(typeof(RowType), new JSTable<RowType>());
            return this;
        }
    
        public JSTable<RowType> GetJSTable<RowType>()
        {
            Tables.TryGetValue(typeof(RowType), out object temp);
            return (JSTable<RowType>)temp;
        }
    }
