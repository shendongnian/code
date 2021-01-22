    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand)) {
        DataSet petsDataSet = new DataSet();
        SqlCacheDependency petsSqlCacheDependency = 
            new SqlCacheDependency(sqlCommand);
        sqlDataAdapter.Fill(petsDataSet, "Pets");
        Cache.Insert("Pets", petsDataSet, petsSqlCacheDependency,
            DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration);
    } 
