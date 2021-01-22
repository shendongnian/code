    public static string ToSqlStatement(this SqlCommand cmd)
    {
    	return $@"EXECUTE sp_executesql N'{cmd.CommandText.Replace("'", "''")}'{cmd.Parameters.ToSqlParameters()}";
    }
    
    private static string ToSqlParameters(this SqlParameterCollection col)
    {
    	if (col.Count == 0)
    		return string.Empty;
    	var parameters = new List<string>();
    	var parameterValues = new List<string>();
    	foreach (SqlParameter param in col)
    	{
    		parameters.Add($"{param.ParameterName}{param.ToSqlParameterType()}");
    		parameterValues.Add($"{param.ParameterName} = {param.ToSqlParameterValue()}");
    	}
    	return $",N\'{string.Join(",", parameters)}\',{string.Join(",", parameterValues)}";
    }
    
    private static object ToSqlParameterType(this SqlParameter param)
    {
    	var paramDbType = param.SqlDbType.ToString().ToLower();
    	if (param.Precision != 0 && param.Scale != 0)
    		return $"{paramDbType}({param.Precision},{param.Scale})";
    	if (param.Precision != 0)
    		return $"{paramDbType}({param.Precision})";
    	switch (param.SqlDbType)
    	{
    		case SqlDbType.VarChar:
    		case SqlDbType.NVarChar:
    			string s = param.SqlValue?.ToString() ?? string.Empty;
    			return paramDbType + (s.Length > 0 ? $"({s.Length})" : string.Empty);
    		default:
    			return paramDbType;
    	}
    }
    
    private static string ToSqlParameterValue(this SqlParameter param)
    {
    	switch (param.SqlDbType)
    	{
    		case SqlDbType.Char:
    		case SqlDbType.Date:
    		case SqlDbType.DateTime:
    		case SqlDbType.DateTime2:
    		case SqlDbType.DateTimeOffset:
    		case SqlDbType.NChar:
    		case SqlDbType.NText:
    		case SqlDbType.NVarChar:
    		case SqlDbType.Text:
    		case SqlDbType.Time:
    		case SqlDbType.VarChar:
    		case SqlDbType.Xml:
    			return $"\'{param.SqlValue.ToString().Replace("'", "''")}\'";
    		case SqlDbType.Bit:
    			return param.SqlValue.ToBooleanOrDefault() ? "1" : "0";
    		default:
    			return param.SqlValue.ToString().Replace("'", "''");
    	}
    }
    
    public static bool ToBooleanOrDefault(this object o, bool defaultValue = false)
    {
    	if (o == null)
    		return defaultValue;
    	string value = o.ToString().ToLower();
    	switch (value)
    	{
    		case "yes":
    		case "true":
    		case "ok":
    		case "y":
    			return true;
    		case "no":
    		case "false":
    		case "n":
    			return false;
    		default:
    			bool b;
    			if (bool.TryParse(o.ToString(), out b))
    				return b;
    			break;
    	}
    	return defaultValue;
    }
