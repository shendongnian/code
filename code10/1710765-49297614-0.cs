    DataSet ExecuteTableValuedFunction(string functionName, params SqlParameter[] parameters)
    {
        var sql = "SELECT * FROM ["+ functionName +"]";
        if(parameters.Length > 0)
        {
            sql += "("+  string.Join(",", parameters.Select(p => p.ParameterName)) +")";
        }
        using(var con = new SqlConnection(_connectionString))
        {
            using(var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parameters);
                using(var adapter = new SqlDataAdapter(cmd))
                {
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
    }
