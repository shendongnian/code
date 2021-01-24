        public void SPRandom()
        {
            OracleConnection connection = this.Database.GetOracleConnection();
            bool needClose = false;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                needClose = true;
            }
            try
            {
                using (OracleCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"Random.SP_Random";
                    OracleParameter outParameter = cmd.CreateParameter();
                    outParameter.ParameterName = "r_cursor";
                    outParameter.ParameterType = OracleDbType.Cursor;
                    outParameter.Direction = ParameterDirection.Output;
                  
                    cmd.Parameters.Add(outParameter);
                    using (OracleDataReader reader =  cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                             .... read your data
                        }
                    }
                }
            }
            finally
            {
                if (needClose)
                {
                    connection.Close();
                }
            }
        }
