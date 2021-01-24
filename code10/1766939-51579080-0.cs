    private Object thisLock = new Object(); 
    public List<TResult> ExecuteStoredProcedure<TResult>(string storedProcedureName, object parameters) where TResult : new()
    {
        lock (thisLock)  
        {  
            Type type = typeof(TResult);
            StringBuilder sb = new StringBuilder();
            sb.Append($"EXEC {storedProcedureName}");
            if (parameters == null)
                parameters = new { };
            var properties = parameters.GetType().GetProperties();
            object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                sb.Append("@");
                sb.Append(properties[i].Name);
                sb.Append("=");
                sb.Append("@p");
                sb.Append(i);
                if (i < properties.Length - 1)
                {
                    sb.Append(",");
                }
                values[i] = properties[i].GetValue(parameters);
            }
            if (type == typeof(ActionModel) || type.BaseType == typeof(ActionModel))
            {
                sb.AppendLine("");
                sb.AppendLine("WITH RESULT SETS ((IsValid BIT NULL,Id BIGINT NULL,Message NVARCHAR(MAX) NULL));");
            }
            return Database.SqlQuery<TResult>(sb.ToString(), values).ToList();
        }
    }
