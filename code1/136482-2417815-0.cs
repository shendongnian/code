    string sql = "INSERT INTO [MyTable] (MyDateColumn) VALUES (@MyDate)"
    using (var cn = new SqlConnection("..connection string.."))
    using (var cmd = new SqlCommand(sql, cn))
    {
        cmd.Parameters.Add("@MyDate", SqlDbType.DateTime).Value = MydateVar;
        
    //remain code omitted
