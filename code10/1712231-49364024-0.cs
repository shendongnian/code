    string sql = "[YourSPName]";
    
    using (var connection = new new SqlConnection("Connection String"))
    {
        connection.Open();
    
        using (var multi = connection.QueryMultiple(sql, param: { }, commandType: CommandType.StoredProcedure))
        {
            var List2 = reader.Read<CategoryOne>().ToList();
            var List1 = reader.Read<CategoryTwo>().ToList();
        }
    }
