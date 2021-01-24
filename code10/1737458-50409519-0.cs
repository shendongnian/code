    public static IEnumerable<T> ListReader<T>(string SQL, string DbName = "TEST")
    {
        using (IDbConnection cmd = new SqlConnection(ConfigurationManager.ConnectionStrings[DbName].ConnectionString))
        {
            return cmd.Query<T>(SQL).ToList();
        }
    }
