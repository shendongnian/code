    using (var command = new SqlCommand(connection, "dbo.MyProc"))
    {
        try
        {
            command.Execute();
        }
        catch (SqlException ex)
        {
            throw new SqlException(ex.Message + " - " + command.Text, ex);
        }
    }
