    public static T GetScalar<T>(string connectionStringKey, string storedProcedure, Parameters parameters) {
        try {
            List<Parameter> outs = null;
            SqlCommand command = GetCommandWithConnection(connectionStringKey);
            command.CommandText = storedProcedure;
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null) {
                outs = parameters.FindAll(p => p.Direction != ParameterDirection.Input);
                parameters.ForEach(p => command.Parameters.AddWithValue(p.Key, p.Value).Direction = p.Direction);
            }
            command.Connection.Open();
            object o = command.ExecuteScalar();
            T result = (o != null) ? (T)o : default(T);
            if (outs != null && outs.Count > 0) {
                foreach (Parameter parameter in outs) {
                    SqlParameter sqlParameter = command.Parameters[parameter.Key];
                    parameters[parameter.Key] = (sqlParameter.Value == DBNull.Value) ? null : sqlParameter.Value;
                }
            }
            command.Connection.Close();
            if (o == null && (typeof(T) == typeof(int)) && parameters != null && parameters.ContainsKey("RowCount"))
                result = (T)parameters["RowCount"];
            return result;
        }
        catch (Exception e) {
            Log.Error(String.Format("Error in GetScalar<{0}>, executing sp: {1}", typeof(T).Name, storedProcedure), e);
            throw;
        }
    }
