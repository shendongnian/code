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
            return _dataRow.Table.Columns.Cast<DataColumn>()
                   .Select((column, i) => new DataRowField
                   {
                       Index = i,
                       Name = column.ColumnName,
                       Value = _dataRow[column]
                   });
        }
    }
