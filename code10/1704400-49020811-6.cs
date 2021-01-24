    //updated to remove the earlier explanatory comments 
    //  and show example methods for isolating SQL from the rest of the application.
    public class MySqlDb
    {
        private string ConnectionString { get; set;} 
        private string ReadConnectionStringFromConfigFile()
        {
            //TODO
            throw NotImplementedException();
        }
        public MySqlDb()
        {
            ConnectionString = ReadConnectionStringFromConfigFile();
        }
     
        private IEnumerable<T> RunSelectQuery(string query, Func<IDataReader, T> translateRecord, IEnumerable<MySqlParameter> parameters)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, cn)
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
                        yield return translateRecord(rdr);
                    }
                    rdr.Close();
                } 
            }
    
        }
        public MetaData GetMetaDataById(int ID)
        {
            string sql = "SELECT * FROM MetatData WHERE ID= @ID";
            var parameters = new List<MySqlParameters> {
               new MySqlParameter() {
                 ParameterName = "@ID",
                 MySqlDbType = MySqlDbType.Int32,
                 Value = ID
               }
            };
            
            return RunSelectQuery(sql, parameters, r =>
                            new Metadata {
                                Id = r["id"],
                                Title = r["title"],
                                Sku = r["sku"],
                                IsLive = r["islive"],
                            }).FirstOrDefault();
        }
        public User GetUserByID(int ID)
        {
            string sql = "SELECT * FROM User WHERE ID= @ID";
            var parameters = new List<MySqlParameters> {
               new MySqlParameter() {
                 ParameterName = "@ID",
                 MySqlDbType = MySqlDbType.Int32,
                 Value = ID
               }
            };
            
            return RunSelectQuery(sql, parameters, r =>
                            new Metadata {
                                Id = r["id"],
                                UserName = r["UserName"],
                                Age = r["Age"],
                                Address = r["Address"],
                            }).FirstOrDefault();
        }
        public User GetUserByUsername(string UserName)
        {
            string sql = "SELECT * FROM User WHERE Username= @UserName";
            var parameters = new List<MySqlParameters> {
               new MySqlParameter() {
                 ParameterName = "@UserName",
                 MySqlDbType = MySqlDbType.VarChar,
                 Size = 20, //guessing at username lenght
                 Value = UserName
               }
            };
            
            return RunSelectQuery(sql, parameters, r =>
                            new Metadata {
                                Id = r["id"],
                                UserName = r["UserName"],
                                Age = r["Age"],
                                Address = r["Address"],
                            }).FirstOrDefault();
        }
        public IEnumerable<User> FindUsersByAge(int Age)
        {
            string sql = "SELECT * FROM User WHERE Age = @Age";
            var parameters = new List<MySqlParameters> {
               new MySqlParameter() {
                 ParameterName = "@Age",
                 MySqlDbType = MySqlDbType.Int32,
                 Value = Age
               }
            };
            
            return RunSelectQuery(sql, parameters, r =>
                            new Metadata {
                                Id = r["id"],
                                UserName = r["UserName"],
                                Age = r["Age"],
                                Address = r["Address"],
                            });
        }
    }
