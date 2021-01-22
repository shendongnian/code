C#
public static class DataRecordExtensions
{
        public static bool HasColumn(IDataReader dataReader, string columnName)
        {
            dataReader.GetSchemaTable().DefaultView.RowFilter = $"ColumnName= '{columnName}'";
            return (dataReader.GetSchemaTable().DefaultView.Count > 0);
        }
}
