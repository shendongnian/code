    public DbRawSqlQuery<T> ExecuteStoredProcedure<T>(string storedProcedureName, params object[] parameters)
            {            string storedProcedureCommand = "CALL " + storedProcedureName + "(";
    
                List<object> augmentedParameters = parameters.ToList();
    
                MySqlParameter[] queryParams;
                storedProcedureCommand = AddParametersToCommand(storedProcedureCommand, augmentedParameters, out queryParams);
    
                storedProcedureCommand += ");";
    
    
    
                return ((DbContext)this).Database.SqlQuery<T>(storedProcedureCommand, queryParams);
            }
    
    
    
            private string AddParametersToCommand(string storedProcedureCommand, List<object> augmentedParameters, out MySqlParameter[] queryParams)
            {
                string paramName = "";
                queryParams = new MySqlParameter[augmentedParameters.Count()];
                for (int i = 0; i < augmentedParameters.Count(); i++)
                {
                    paramName = "p" + i;
                    queryParams[i] = new MySqlParameter(paramName,augmentedParameters[i]);                                
                    storedProcedureCommand += "@" + paramName;
    
                    if (i < augmentedParameters.Count - 1)
                    {
                        storedProcedureCommand += ",";
                    }
                }
                return storedProcedureCommand;
            }
