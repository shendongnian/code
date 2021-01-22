    using (var command = new SqlCommand(connection, "dbo.MyProc"))
    {
        try
        {
            command.Execute();
        }
        catch (DbException ex)
        {
            throw new InvalidOperationException(ex.Message + " - " + command.Text, ex);
        }
    }
