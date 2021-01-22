        public SqlDataReader ExecuteReader(string command, SqlParameter[] parameters)
        {
            SqlDataReader reader = null;
            using (SqlConnection conn = new SqlConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            return reader;
        }
