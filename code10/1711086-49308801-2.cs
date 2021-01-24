    protected static DataTable GetDataTable(SqlCommand command) =>
        ExecuteCommand(cmd =>
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd)
            DataTable table = new DataTable();
            da.FillTable(table);
            return table;
        });
