    public class MyFormOrPage
    {
        void UsageExample()
        {
            DataTable allDataTable = new DataTable();
            // populate the data table with whatever logic ...
            // wrap the data table to expose only the Name, Address, and PhoneNumber columns
            var limitedDataTable = new DataTableWrapper(allDataTable, "Name", "Address", "PhoneNumber");
            // iterate over the rows
            foreach (var limitedDataRow in limitedDataTable)
            {
                // iterate over the columns
                for (int i = 0; i < limitedDataTable.ColumnCount; i++)
                {
                    object value = limitedDataRow[i];
                    // do something with the value ...
                }
            }
            // bind the wrapper to a control
            MyGridControl.DataSource = limitedDataTable;
        }
    }
    public class DataTableWrapper : IEnumerable<DataRowWrapper>
    {
        private DataTable _Table;
        private string[] _ColumnNames;
        public DataTableWrapper(DataTable table, params string[] columnNames)
        {
            this._Table = table;
            this._ColumnNames = columnNames;
        }
        public int ColumnCount
        {
            get { return this._ColumnNames.Length; }
        }
        public IEnumerator<DataRowWrapper> GetEnumerator()
        {
            foreach (DataRow row in this._Table.Rows)
            {
                yield return new DataRowWrapper(row, this._ColumnNames);
            }
        }
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
        // if you _really_ want to make a copy of the DataTable, you can use this method
        public DataTable CopyToDataTable()
        {
            DataTable copyTable = new DataTable();
            for (int index = 0; index < this._ColumnNames.Length; index++)
            {
                DataColumn column = this._Table.Columns[index];
                copyTable.Columns.Add(column);
            }
            foreach (DataRow row in this._Table.Rows)
            {
                DataRow copyRow = copyTable.NewRow();
                for (int index = 0; index < this._ColumnNames.Length; index++)
                {
                    copyRow[index] = row[this._ColumnNames[index]];
                }
                copyTable.Rows.Add(copyRow);
            }
            return copyTable;
        }
    }
    // let's make this a struct, since potentially very many of these will be instantiated
    public struct DataRowWrapper
    {
        private DataRow _Row;
        private string[] _ColumnNames;
        public DataRowWrapper(DataRow row, params string[] columnNames)
        {
            this._Row = row;
            this._ColumnNames = columnNames;
        }
        // use this to retrieve column values from a row
        public object this[int index]
        {
            get { return this._Row[this._ColumnNames[index]]; }
            set { this._Row[this._ColumnNames[index]] = value; }
        }
        // just in case this is still needed...
        public object this[string columnName]
        {
            get { return this._Row[columnName]; }
            set { this._Row[columnName] = value; }
        }
    }
