        /// <summary>
        /// Get data from the returning refcursor of postgresql function
        /// </summary>
        /// <param name="FunctionName">Function name of postgresql</param>
        /// <param name="Parameters">parameters to pass to the postgresql function</param>
        /// <param name="ErrorOccured">out bool parameter to check if it occured error</param>
        /// <returns></returns>
        public List<DataTable> GetRefCursorData(string FunctionName, List<object> Parameters, out bool ErrorOccured)
        { 
            string connectstring = ""; //your connectstring here
            List<DataTable >  dtRtn =new List<DataTable>();
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = null;            
            try
            {
                connection = new NpgsqlConnection(connectstring);
                transaction = connection.BeginTransaction();
                command = new NpgsqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = FunctionName;
                command.Transaction = transaction;
                //
                if (Parameters != null)
                {
                    foreach (object item in Parameters)
                    {
                        NpgsqlParameter parameter = new NpgsqlParameter();
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Value = item;
                        command.Parameters.Add(parameter);
                    }
                }
                //
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    DataTable dt = new DataTable();
                    command = new NpgsqlCommand("FETCH ALL IN " + "\"" + dr[0].ToString() + "\"", Connection); //use plpgsql fetch command to get data back
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dt);
                    dtRtn.Add(dt); //all the data will save in the List<DataTable> ,no matter the connection is closed or returned multiple refcursors
                }                
                ErrorOccured = false;
                transaction.Commit();
            }
            catch
            { 
                //error handling ...
                ErrorOccured = true;
                if (transaction != null) transaction.Rollback();
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            return dtRtn;
        }
