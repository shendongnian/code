    public class AdvancedDataTable : DataTable
    {
        public IEnumerable<DataRow> InsertedRowList
        {
            get
            {
                foreach (DataRow row in this.Rows)
                {
                    if (row.RowState == System.Data.DataRowState.Added)
                    {
                        yield return row;
                    }
                }
            }
        }
    }
