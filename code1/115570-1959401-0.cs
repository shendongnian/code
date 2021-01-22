    public class TableAdapterWrapper
    {
        object tableAdapter;
        DataTable table;
        public TableAdapterWrapper(object tableAdapter, DataTable table)
        {
            this.tableAdapter = tableAdapter;
            this.table = table;
        }
        public void Fill()
        {
            var methodInfo = tableAdapter.GetType().GetMethod("Fill");
            methodInfo.Invoke(tableAdapter, new object[] { table });
        }
    }
