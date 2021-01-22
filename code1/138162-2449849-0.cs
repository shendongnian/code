    public static decimal pobierzBenchmarkKolejny(string varPortfelID, DateTime data, decimal varBenchmarkPoprzedni, decimal varStopaOdniesienia) {
        const string preparedCommand = @"SELECT [dbo].[ufn_BenchmarkKolejny](@varPortfelID, @data, @varBenchmarkPoprzedni,  @varStopaOdniesienia) AS 'Benchmark'";
        using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetailsDZP)) //if (varConnection != null) {
        using (var sqlQuery = new SqlCommand(preparedCommand, varConnection)) {
    
            sqlQuery.Parameters.Add("@varPortfelID");
            sqlQuery.Parameters.Add("@varStopaOdniesienia");
            sqlQuery.Parameters.Add("@data");
            sqlQuery.Parameters.Add("@varBenchmarkPoprzedni");
            
            sqlQuery.Prepare();
            sqlQuery.ExecuteNonQuery();//This might need to be ExecuteReader()
            sqlQuery.Parameters[0].Value = varPortfelID;
            sqlQuery.Parameters[1].Value = varStopaOdniesienia;
            sqlQuery.Parameters[2].Value = data;
            sqlQuery.Parameters[3].Value = varBenchmarkPoprzedni;
            using (var sqlQueryResult = sqlQuery.ExecuteReader())
                if (sqlQueryResult != null) {
                    while (sqlQueryResult.Read()) {
    
                    }
                }
        }
    }
