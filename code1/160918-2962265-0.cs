    public void DoQuery(string table, Dictionary<string, object> columns)
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT ");
        foreach (KeyValuePair<string, object> kvp in columns)
        {
            query.Append(kvp.Key).Append(","); // You need extra logic to not append a trailing comma.  Exercise to reader ;-)
        }
    
        // Etc.  Look at how to add parameters to your where clause using provided link
         
    }
