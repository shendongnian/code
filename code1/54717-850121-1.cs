    public IEnumerable<IDataRecord> GetSomeData(string filter)
    {
        string sql = "SELECT * FROM [SomeTable] WHERE SomeColumn= @Filter";
        using (SqlConnection cn = new SqlConnection(GetConnectionString()))
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
            cmd.Parameters.Add("@Filter", SqlDbType.NVarChar, 255).Value = filter;
            cn.Open();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    yield return (IDataRecord)rdr;
                }
            }
        }
    }
