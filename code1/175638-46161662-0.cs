    class Database
    {
        private MySqlConnection connecting;
        private MySqlDataAdapter adapter;
        public Database()
            {
            connecting = new MySqlConnection("server=;uid=;pwd=;database=;");
            connecting.Open();
            }
        public DataTable GetTable(string tableName)
        {
            adapter = new MySqlDataAdapter("SELECT * FROM "+ tableName, connecting);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            adapter.UpdateCommand = new MySqlCommandBuilder(adapter).GetUpdateCommand(); 
            adapter.DeleteCommand = new MySqlCommandBuilder(adapter).GetDeleteCommand(); 
            ds.Tables[0].RowChanged += new DataRowChangeEventHandler(Rowchanged);
            ds.Tables[0].RowDeleted += new DataRowChangeEventHandler(Rowchanged);
            return ds.Tables[0];
        }
        public void Rowchanged(object sender, DataRowChangeEventArgs args)
        {
            adapter.Update(sender as DataTable);
        }
    }
}
