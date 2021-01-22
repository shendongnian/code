    public static class SqlParameterExtensions
    {
        public static T GetValueOrDefault<T>(this SqlParameter sqlParameter)
        {
            if (sqlParameter.Value == DBNull.Value)
            {
                if (typeof(T).IsValueType)
                    return (T) Activator.CreateInstance(typeof(T));
    
                return (default(T));
            }
    
            return (T) sqlParameter.Value;
        }
    }
    
    
    // Usage
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand("storedProcedure", conn))
    {
       SqlParameter outputIdParam = new SqlParameter("@ID", SqlDbType.Int)
       { 
          Direction = ParameterDirection.Output 
       };
    
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(outputIdParam);
    
       conn.Open();
       cmd.ExecuteNonQuery();
       
       int result = outputIdParam.GetValueOrDefault<int>();
    }
