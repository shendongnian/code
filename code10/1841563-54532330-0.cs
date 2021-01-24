    public bool checkConnection(string connection_string)
    {
        var client = new MongoClient(connection_string)
        try 
        {
            client.ListDatabaseNames();
        }
        catch (Exception)
        {
        }
        return client.Cluster.Description.State == ClusterState.Connected;
    }
