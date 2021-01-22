    public class MyDataTable : DataTable
    {
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new MyDataRow(builder);
        }
    }
