    public class RepositorySql : IRepository
    {
        public IEnumerable<MyModel> GetModel(int id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SomeConnectionString"].ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NameOfStoredProcedure";
                cmd.Parameters.AddWithValue("@parameter", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new MyModel
                        {
                            Column1 = reader["column1"].ToString(),
                            Column2 = reader["column2"].ToString()
                        };
                    }
                }
            }
        }
    }
