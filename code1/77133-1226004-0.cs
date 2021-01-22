        /// <summary>
        /// Executes a stored procedure or query, returns the number of rows effected.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public static int ExecuteQuery(string commandText, CommandType commandType, List<SqlParameter> sqlParameters, SqlTransaction sqlTransaction)
        {
            if (sqlTransaction == null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandType = commandType;
                        sqlCommand.CommandText = commandText;
                        if (sqlParameters != null)
                        {
                            foreach (SqlParameter sqlParameter in sqlParameters)
                            {
                                sqlCommand.Parameters.Add(sqlParameter);
                            }
                        }
                        return sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlTransaction.Connection, sqlTransaction);
                sqlCommand.CommandType = commandType;
                foreach (SqlParameter sqlParameter in sqlParameters)
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                }
                return sqlCommand.ExecuteNonQuery();
            }
        }
