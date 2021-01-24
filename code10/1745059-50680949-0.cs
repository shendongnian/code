    private SqlDataReader ExecuteQuery(string query)
    {
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
    
            newQuery = connection.CreateCommand();
            newQuery.CommandText = query;
            newQuery.Transaction = transaction;
    
            var result = newQuery.ExecuteReader();
            return result;
        }
    
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
            throw;
        }
    }
