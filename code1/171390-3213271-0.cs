    public class DataRowField
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public IEnumerable<DataRowField> Fields
    {
        get
        {
            int i = 0;
            return from column in _dataRow.Table.Columns.Cast<DataColumn>()
                   select new DataRowField
                   {
                       Index = i++,
                       Name = column.ColumnName,
                       Value = _dataRow[column]
                   };
        }
    }
