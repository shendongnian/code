    // using MySql.Data.MySqlClient; // remember to include this
    
    /* Helper method that takes in a Dictionary list of parameters, 
       and returns a DataTable. 
       The connection string is fetched from a resources file. */
    public static DataTable ExecuteProc(string procedureName, Dictionary<string,object> parameterList)
    {
        DataTable outputDataTable;
    
        using (MySqlConnection MySqlConnection = new MySqlConnection(Resources.SQL_CONNECTION_STRING))
        {
            using (MySqlCommand sqlCommand = new MySqlCommand(procedureName, MySqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
    
                if (parameterList != null)
                {
                    foreach(string key in parameterList.Keys)
                    {
                        string parameterName = key;
                        object parameterValue = parameterList[key];
    
                        sqlCommand.Parameters.Add(new MySqlParameter(parameterName, parameterValue));
                    }
                }
    
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                DataSet outputDataSet = new DataSet();
                sqlDataAdapter.Fill(outputDataSet, "resultset");
    
                outputDataTable = outputDataSet.Tables["resultset"];
            }
        }
    
        return outputDataTable;
    }
