    static void Main(string[] args)
    {
    	int? i = GetValueOrNull<int>(null, string.Empty);
    }
    
    
    public static Nullable<T> GetValueOrNull<T>(DbDataRecord reader, string columnName) where T : struct
    {
    	object columnValue = reader[columnName];
    
    	if (!(columnValue is DBNull))
    		return (T)columnValue;
    
    	return null;
    }
