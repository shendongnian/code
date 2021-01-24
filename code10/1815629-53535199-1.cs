        #region This function updates the datatable when a row has been altered in the datagrid.
        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            db.Update();
        }
        #endregion
        #region This function updates the datatable when a row has been deleted in the datagrid.
        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            db.Update();
        }
        #endregion
    
    //db.Update calls a function inside my MySQL Code, which looks like this:
    
    public DataSet Update()
    {
        string query = "Select * from Recepten";
        using (MySqlConnection cnn = new MySqlConnection(connectionString))
        using (MySqlCommand cmd4 = new MySqlCommand(query,cnn))
        using(adp = new MySqlDataAdapter(cmd4))
        using (MySqlCommandBuilder myBuilder = new MySqlCommandBuilder(adp))
        {
            cnn.Open();
            adp.Update(dt);
        }
        return dt;
    }
