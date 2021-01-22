    public void CallStoredProc()
    {
        using(SqlConnection con = new SqlConnection(.....))
        using(SqlCommand cmd = new SqlCommand("tax_Base_emp", con))
        {
           cmd.CommandType = CommandType.StoredProcedure;
           AddParameter(cmd.Parameters, "@emp_code", SqlDbType.BigInt, emp_code);
           AddParameter(cmd.Parameters, "@co_id", SqlDbType.BigInt, comp_id);
           AddParameter(cmd.Parameters, "@d", SqlDbType.DateTime, Convert.ToDateTime("31/1/2010"));
           AddParameter(cmd.Parameters, "@y", SqlDbType.Int, int.Parse(textBox2.Text));
           AddParameter(cmd.Parameters, "@check_month", SqlDbType.Int, 1);
           AddParameter(cmd.Parameters, "@month", SqlDbType.Int, 8);
           AddParameter(cmd.Parameters, "@indate", SqlDbType.DateTime, Convert.ToDateTime("8/5/2010"));
           
           AddOutputParameter(cmd.Parameters, "@Sumtotal", SqlDbType.Decimal, 8, 2);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
           decimal tax_value = Convert.ToDecimal(cmd.Parameters["@Sumtotal"].Value);
       }
    }
    public void AddParameter(SqlParameterCollection params, string name, SqlDbType type, object value)
    {
        SqlParameter tmpParam = new SqlParameter(name, type); 
        tmpParam.Value = value; 
        params.Add(tmpParam);
    }
    public void AddOutputParameter(SqlParameterCollection params, string name, SqlDbType type, int precision, int scale)
    {
        SqlParameter tmpParam = new SqlParameter(name, type); 
        tmpParam.ParameterDirection = Direction.Output;
        tmpParam.Precision = precision; 
        tmpParam.Scale = scale; 
        params.Add(tmpParam);
    }
