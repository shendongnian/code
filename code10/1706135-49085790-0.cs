    try
    {
        Connection.Open();
        using (Command cmd = Connection.CreateCommand())
        {
        }
    }
    catch (SqlException ex)
    {
        Console.Error.WriteLine(ex.Message);
        return new StoredProcRet(-1, null);
    }
    finally 
    {
        Connection.Close();
    }
