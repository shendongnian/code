    class DatabaseContext : IDisposable {
        List<DatabaseContext> currentContexts;
        SqlConnection connection;
        bool first = false; 
        DatabaseContext (List<DatabaseContext> contexts)
	    {
            currentContexts = contexts;
            if (contexts.Count == 0)
            {
                connection = new SqlConnection(); // fill in info 
                connection.Open();
                first = true;
            }
            else
            {
                connection = contexts.First().connection;
            }
            contexts.Add(this);
        }
       static List<DatabaseContext> DatabaseContexts {
            get
            {
                var contexts = CallContext.GetData("contexts") as List<DatabaseContext>;
                if (contexts == null)
                {
                    contexts = new List<DatabaseContext>();
                    CallContext.SetData("contexts", contexts);
                }
                return contexts;
            }
        }
        public static DatabaseContext GetOpenConnection() 
        {
            return new DatabaseContext(DatabaseContexts);
        }
        public SqlCommand CreateCommand(string sql)
        {
            var cmd = new SqlCommand(sql);
            cmd.Connection = connection;
            return cmd;
        }
        public void Dispose()
        {
            if (first)
            {
                connection.Close();
            }
            currentContexts.Remove(this);
        }
    }
 
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
