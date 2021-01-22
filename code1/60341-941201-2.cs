    public T[] ExecuteReader<T>(string cmdTxt)
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
               using(SqlCommand cmd = new SqlCommand(cmdTxt, conn))
               {
                    conn.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        var result=new List<T>();
                        while(reader.Read())
                             result.Add(ObjectMapper.MapReader<T>(reader));
                        return result.ToArray();
                    }
           }
        }
    }
