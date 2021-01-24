     public List<string> GetConfigurationValues(string configurationKey, int? idBusinessUnit, int? idDomain)
        {
            string conn = ConnectionStringHelper.GetIdentityConnectionString();
            string valueRes;
            int idConfigurationKey = 0;
            if (configurationKey == "PORTAL_THEME") { idConfigurationKey = 3; }
            else if (configurationKey == "LOGO_THEME") { idConfigurationKey = 4; }
            List<string> conf = new List<string>();
            DataTable dt = new DataTable();
            using (SqlConnection dbConnection = new SqlConnection(conn))
            {
                dbConnection.Open();
                SqlCommand command = dbConnection.CreateCommand();
                SqlTransaction transaction;
                transaction = dbConnection.BeginTransaction("SampleTransaction");
                command.Connection = dbConnection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = @"
                        SELECT Value 
                        FROM ConfigurationValue cv
                        INNER JOIN ConfigurationFilter cf ON cv.idConfigurationValue = cf.idConfigurationValue
                        INNER JOIN ConfigurationKey ck ON ck.idConfigurationKey = cf.idConfigurationKey
                        WHERE cf.idConfigurationKey = @ConfigurationKey
                        AND((cf.idDomain = @idDomain) OR(cf.idDomain IS NULL))
                        AND((cf.idBusinessUnit = @idBusinessUnit) OR(cf.idBusinessUnit IS NULL))";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.Add(new SqlParameter("@ConfigurationKey", idConfigurationKey));
                if (idBusinessUnit == null)
                        command.Parameters.Add(new SqlParameter("@idBusinessUnit", DBNull.Value)); //DBNull.Value
                else
                        command.Parameters.Add(new SqlParameter("@idBusinessUnit", idBusinessUnit));
                if (idDomain == null)
                        command.Parameters.Add(new SqlParameter("@idDomain", null));// DBNull.Value
                else
                        command.Parameters.Add(new SqlParameter("@idDomain", idDomain));
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string theme = reader["Value"].ToString();
                            conf.Add(theme);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                
                }
            
            }
            return conf;
        }
