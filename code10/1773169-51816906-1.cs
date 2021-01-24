    //Opening Connection
    public SqlConnection GetConnection(string connectionName)
    {
      string cnstr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
      SqlConnection cn = new SqlConnection(cnstr);
      cn.Open();
      return cn;
    }
    //for select 
    public DataSet ExecuteQuery(
      string connectionName,
      string storedProcName,
      Dictionary<string, sqlparameter=""> procParameters
    )
    {
      DataSet ds = new DataSet();
      using(SqlConnection cn = GetConnection(connectionName))
      {
          using(SqlCommand cmd = cn.CreateCommand())
          {
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = storedProcName;
              // assign parameters passed in to the command
              foreach (var procParameter in procParameters)
              {
                cmd.Parameters.Add(procParameter.Value);
              }
              using (SqlDataAdapter da = new SqlDataAdapter(cmd))
              {
                da.Fill(ds);
              }
          }
     }
     return ds;
    }
    
    //for insert,update,delete
    
    public int ExecuteCommand(
      string connectionName,
      string storedProcName,
      Dictionary<string, SqlParameter> procParameters
    )
    {
      int rc;
      using (SqlConnection cn = GetConnection(connectionName))
      {
        // create a SQL command to execute the stored procedure
        using (SqlCommand cmd = cn.CreateCommand())
        {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = storedProcName;
          // assign parameters passed in to the command
          foreach (var procParameter in procParameters)
          {
            cmd.Parameters.Add(procParameter.Value);
          }
          rc = cmd.ExecuteNonQuery();
        }
      }
      return rc;
    }
