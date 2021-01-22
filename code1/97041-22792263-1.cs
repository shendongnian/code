    Dictionary<Type, SqlDbType> GetSQLTypeConversionMap()
    {
    	var result = new Dictionary<Type, SqlDbType>();
    	result.Add(typeof(string), SqlDbType.VarChar);
    	result.Add(typeof(Int16), SqlDbType.Int);
    	result.Add(typeof(Int32), SqlDbType.Int);
    	result.Add(typeof(DateTime), SqlDbType.DateTime2);
    	return result;	
    }
