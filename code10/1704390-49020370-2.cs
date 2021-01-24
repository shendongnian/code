    public List<T> RunSelectQuery<T>(string query)
    {
        try // implement proper error handling
        {
            Connection.Open();
            metadata = Connection.Query<T>(query).ToList();
            Connection.Close();
        }
        catch(Exception ex)
        {
            // error here
        }
        return metadata;
    }
