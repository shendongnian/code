    public static object GetStringOrDBNull(this string obj)
    {
             return string.IsNullOrEmpty(obj) ? DBNull.Value : (object) obj;
    }
    
    myCmd.Parameters.Add("@MiddleName", MiddleName.GetStringOrDBNull());
