        public static List<T> ExecuteStoredProcedure<T>(this DbContext dbContext, string storedProcedureName, params object[] parameters)
        {
            string storedProcedureCommand = "CALL " + storedProcedureName + "(";
            List<object> augmentedParameters = parameters.ToList();
            storedProcedureCommand = AddParametersToCommand(storedProcedureCommand, augmentedParameters);
            storedProcedureCommand += ");";
            return dbContext.Database.SqlQuery<T>(storedProcedureCommand).ToList<T>();
        }
        public static List<T> ExecuteStoredRecursiveProcedure<T>(this DbContext dbContext, string storedProcedureName, params object[] parameters)
        {
            string storedProcedureCommand = "SET max_sp_recursion_depth = " + maxRecursionCount + "; CALL " + storedProcedureName + "(";
            List<object> augmentedParameters = parameters.ToList();
            storedProcedureCommand = AddParametersToCommand(storedProcedureCommand, augmentedParameters);
            storedProcedureCommand += ");";
            return dbContext.Database.SqlQuery<T>(storedProcedureCommand).ToList<T>();
        }
        private static string AddParametersToCommand(string storedProcedureCommand, List<object> augmentedParameters)
        {
            for (int i = 0; i < augmentedParameters.Count(); i++)
            {
                storedProcedureCommand = AddParameterToCommand(storedProcedureCommand, augmentedParameters, i);
            }
            return storedProcedureCommand;
        }
        private static string AddParameterToCommand(string storedProcedureCommand, List<object> augmentedParameters, int i)
        {
            if (augmentedParameters[i].GetType() == typeof(string))
            {
                storedProcedureCommand += "'";
            }
            storedProcedureCommand += (augmentedParameters[i].ToString());
            if (augmentedParameters[i].GetType() == typeof(string))
            {
                storedProcedureCommand += "'";
            }
            if (i < augmentedParameters.Count - 1)
            {
                storedProcedureCommand += ",";
            }
            return storedProcedureCommand;
        }
