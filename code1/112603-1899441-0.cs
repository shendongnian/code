    public IList<DateTime> GetUniqueDates()
    {
        const string CacheKey = "RepositoryName.UniqueDates";
        Cache cache = HttpRuntime.Cache;
        List<DateTime> result = cache.Get[CacheKey] as List<DateTime>;
        if (result == null)
        {
            // If you're application has multithreaded access to data, you might want to 
            // put a double lock check in here
            using (SqlConnection reportConnect = new SqlConnection(ConnectionString))
            {
                // ...
                result = new List<DateTime>();
                while(reader.Read())
                {
                    result.Add((DateTime)reader["Value"]);
                }
            }
            // You can specify various timeout options here
            cache.Insert(CacheKey, result);
        }
        return result;
    }
