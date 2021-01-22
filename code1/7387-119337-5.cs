    public void Commit()
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = "Do the connection using a DSN";
        // open the connection
        cn.Open();
        // commit any data changes
        dataAdapter.DeleteCommand.Connection = cn;
        dataAdapter.InsertCommand.Connection = cn;
        dataAdapter.UpdateCommand.Connection = cn;
        dataAdapter.Update(table);
        dataAdapter.DeleteCommand.Connection = null;
        dataAdapter.InsertCommand.Connection = null;
        dataAdapter.UpdateCommand.Connection = null;
        // clean up
        cn.Close();
    }
