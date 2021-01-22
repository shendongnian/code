    protected void  SqlDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
        for (int x = 0; x <= e.Command.Parameters.Count - 1;x++ )
        {
            string Type = e.Command.Parameters[x].GetType().ToString();
            string Value = e.Command.Parameters[x].ToString();
        }
    }
