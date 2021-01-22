    public DataTable GetRecords(int SomeValue)
    {
        var result = new DataTable();
        string sql = " SELECT * FROM [MyTable] WHERE [SomeIntColumn]= @SomeValue ";
        using (var cn = CreateConnection() )
        using (var cmd = new SqlCommand(sql, cn) )   
        {
            cmd.Parameters.Add("@SomeValue", SqlDbType.Int).Value =  SomeValue;
            
            using (var rdr = cmd.ExecuteReader() )
            {
               result.Load(rdr);
            }
        }
        return result;  
    }
