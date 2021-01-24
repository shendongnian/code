    public class CommandGenerator
    {
        private Dictionary<string, SqlDbType> _columnToDbType;
        private string _tableName;
        private List<SqlCommand> _commands;
        public CommandGenerator(DataTable table, Dictionary<string, SqlDbType> columnToDbType, string tableName = null)
	    {
            _commands = new List<SqlCommand>();
            _columnToDbType = columnToDbType;
            _tableName = (string.IsNullOrEmpty(tableName)) ? tableName : table.TableName;
            
            table.RowDeleted += table_RowDeleted;
            table.RowChanged += table_RowChanged;
	    }
        public IEnumerable<SqlCommand> Commands { get { return _commands; } }
        private void table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            _commands.Add(GenerateDelete(e.Row));
        }
        private void table_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            _commands.Add(GenerateDelete(e.Row));
        }
        private SqlCommand GenerateUpdate(DataRow row)
        {
            
            var table = row.Table;
            var cmd = new SqlCommand();
            var sb = new StringBuilder();
            sb.Append("UPDATE ").Append(_tableName).Append(" SET ");
            
            var valueColumns = table.Columns.OfType<DataColumn>().Where(c => !table.PrimaryKey.Contains(c));
            
            AppendColumns(cmd, sb, valueColumns, row);
            sb.Append(" WHERE ");
            AppendColumns(cmd, sb, table.PrimaryKey, row);
            
            cmd.CommandText = sb.ToString();
            return cmd;
        }
        private SqlCommand GenerateDelete(DataRow row)
        {
            var table = row.Table;
            var cmd = new SqlCommand();
            var sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(_tableName).Append(" WHERE ");
            AppendColumns(cmd, sb, table.PrimaryKey, row);
            cmd.CommandText = sb.ToString();
            return cmd;
        }
        private void AppendColumns(SqlCommand cmd, StringBuilder sb, IEnumerable<DataColumn> columns, DataRow row)
        {
            foreach (var column in columns)
            {
                sb.Append(column.ColumnName).Append(" = @").AppendLine(column.ColumnName);
                cmd.Parameters.Add("@" + column.ColumnName, _columnToDbType[column.ColumnName]).Value = row[column];
            }
        }
    }
