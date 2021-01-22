    class Program
    {
        static void Main(string[] args)
        {
            MyDataTable t = new MyDataTable();
            t.Rows.Add(t.NewRow()); // <-- Exception here, wrong type (base doesn't count).
        }
    }
    
    public class MyDataTable : DataTable
    {
        public MyDataTable()
            : base()
        { }
    
        protected override Type GetRowType()
        {
            return typeof(MyDataRow);
        }
    }
    
    public class MyDataRow : DataRow
    {
        public MyDataRow()
            : base(null)
        { }
    }
