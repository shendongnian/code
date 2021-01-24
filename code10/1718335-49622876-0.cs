    public static bool ColumnExists(this IDataRecord dr, string ColumnName)
    {
    	for (int i=0; i < dr.FieldCount; i++)
    	{
    		if (dr.GetName(i).Equals(ColumnName, StringComparison.InvariantCultureIgnoreCase))
    		    return true;
    	}
    	return false;
    }
