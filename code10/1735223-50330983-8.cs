    public class Repository
    {
        public string ConnectionString { get; private set; }
        public Repository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public string GetSchoolNameById(int id)
        {
            string schoolName = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(this.ConnectionString);
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT School_Name FROM schools WHERE School_ID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("School_Name")))
                            {
                                schoolName = rdr.GetString(rdr.GetOrdinal("School_Name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // maybe log exception here, or rethrow it if you want
                // the consumer to manage it. This depends on how you plan to build your software architecture.
            }
            finally
            {
                // this code will run always, either if everything ran correctly or if some exception occurred in the try block.
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return schoolName;
        }
    }
