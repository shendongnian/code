    public List<Metadata> RunSelectQueryForMetadata(string query)
    {
        var metadata = new List<Metadata>();
        try // implement proper error handling
        {
            Connection.Open();
            metadata = Connection.Query<Metadata>(query).ToList();
            Connection.Close();
        }
        catch(Exception ex)
        {
            // error here
        }
        return metadata;
    }
