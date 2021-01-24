    public string GetBezeichnung(int LP, DateTime date)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_ConnectionString))
        {
            connection.Open();
            string sql = @"
    SELECT ZER_Bezeichnung 
    FROM Z_ERFASSUNG 
    WHERE ZER_LPE = @LP
      AND ZER_Datum = @Date"
            var output = connection.Query<string>(sql, new { LP = LP, date = date }).FirstOrDefault();
            return output;
        }
    }
