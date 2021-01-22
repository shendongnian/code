    public IEnumerable<IDataRecord> GetData()
    {
        using (var cn = getOpenConnection(connectionString))
        using (var cmd = new SqlCommand("GetData", cn))   
        using (var rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                yield return (IDataRecord)rdr;
            }
        }
    }
