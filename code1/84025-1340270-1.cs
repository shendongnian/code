    public static IDataReader GetDataReader(string connectionStringKey, string storedProcedure, Dictionary<string, object> parameters) {
        try {
            SqlCommand command = GetCommandWithConnection(connectionStringKey);
            command.CommandText = storedProcedure;
            command.CommandType = CommandType.StoredProcedure;
            foreach (var parameter in parameters ?? new Dictionary<string, object>())
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            command.Connection.Open();
            return command.ExecuteReader();
        }
        catch (Exception e) {
            Log.Error(string.Format("Error in GetDataReader, executing sp: {0}", storedProcedure), e);
            throw;
        }     
    }
    private static SqlCommand GetCommandWithConnection(string connectionStringKey) {
        return new SqlConnection(GetConnectionString(connectionStringKey)).CreateCommand();
    }
    private static string GetConnectionString(string connectionStringKey) {
        return ConfigurationManager.ConnectionStrings[connectionStringKey].ToString();
    }
