    public object getQueryScaller(string sqlQuery)
        {
            object value = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    conn.Open();
                    value = cmd.ExecuteScalar();
                }
            }
            return value;
        }
