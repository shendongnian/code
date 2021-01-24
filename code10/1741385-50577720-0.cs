    public class JSGridVM
    {
        private Dictionary<Type, object> Tables = new Dictionary<Type, object>();
    
        public JSGridVM AddTable<RowType>()
        {
            Tables.Add(typeof(RowType), new JSTable<RowType>());
            return this;
        }
    
        public JSTable<RowType> GetTable<RowType>()
        {
            Tables.TryGetValue(typeof(RowType), out object temp);
            return (JSTable<RowType>)temp;
        }
    }
