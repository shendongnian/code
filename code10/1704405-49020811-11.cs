    public class MySqlDb
    {
        //1. This should not be public!
        //     Keeping it private forces other code to go through your public methods, 
        //    rather than using the connection directly.
        //     Even better if the class knows how to read the string from a 
        //     config rile rather than accepting it via the constructor.
        //2. Don't save a connection object for re-use.
        //    ADO.Net has a connection pooling feature that works when you 
        //    create new objects for most queries
        private string ConnectionString { get; set;} 
        public MySqlDb(string connectionString)
        {
            ConnectionString = connectionString;
        }
     
        //1. Use IEnumerable instead of List 
        //    ...don't pull of the results into memory at the same time unless you really have to.
        //2. Methods that accept query strings should also accept parameters. 
        //    Otherwise you are forced to build sql strings in insecure crazy-vulnerable ways
        public IEnumerable<Metadata> RunSelectQueryForMetadata(string query, IEnumerable<MySqlParameter> parameters)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, cn))
            {
                if (parameters != null)
                {
                   cmd.Parameters.AddRange(parameters.ToArray());
                }
               cn.Open();
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        yield return new Metadata {
                                Id = rdr["id"],
                                Title = rdr["title"],
                                Sku = rdr["sku"],
                                IsLive = rdr["islive"],
                            };
                    }
                    rdr.Close();
                } 
            }
    
        }
    }
