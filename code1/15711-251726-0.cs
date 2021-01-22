    void Test()
    {
        // connection is opened here
        using (var ctx = DatabaseContext.GetOpenConnection())
        {
            using (var cmd = ctx.CreateCommand("select 1"))
            {
                cmd.ExecuteNonQuery(); 
            }
    
            Test2(); 
        }
        // closed after dispose
    }
    
    void Test2()
    {
        // reuse existing connection 
        using (var ctx = DatabaseContext.GetOpenConnection())
        {
            using (var cmd = ctx.CreateCommand("select 2"))
            {
                cmd.ExecuteNonQuery();
            }
        }
        // leaves connection open
    }
