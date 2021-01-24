    public void Load(ItemsControl control, string commandText)
    {
        try
        {
            _db.OpenConnection();
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(commandText, _db.Connection))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                control.ItemsSource = dataTable.AsDataView();
            }
        }
        catch (Exception exp)
        {
            //...;
        }
    }
