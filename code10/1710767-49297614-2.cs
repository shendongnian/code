    public DataSet ExecuteTableValuedFunction(string functionName, params SqlParameter[] parameters)
    {
        var sqlWhiteList = "SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES " +
                            "WHERE ROUTINE_TYPE = 'FUNCTION'  " +
                            "AND DATA_TYPE = 'TABLE'  " +
                            "AND SPECIFIC_NAME = @FunctionName";
        var sql = "SELECT * FROM " + functionName ;
        if (parameters.Length > 0)
        {
            sql += "(" + string.Join(",", parameters.Select(p => p.ParameterName)) + ")";
        }
        using (var con = new SqlConnection(_connectionString))
        {
            using (var cmdWhiteList = new SqlCommand(sqlWhiteList, con))
            {
                cmdWhiteList.Parameters.Add("@FunctionName", SqlDbType.NVarChar, 128).Value = functionName;
                var exists = cmdWhiteList.ExecuteScalar();
                if (exists != null && exists != DBNull.Value)
                {
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddRange(parameters);
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            var ds = new DataSet();
                            adapter.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }
        return null;
    }
