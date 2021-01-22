    public static T ConvertToTypedDataTable<T>(System.Data.DataTable dtBase) where T : Data.DataTable, new()
    {
    	T dtTyped = new T();
    	dtTyped.Merge(dtBase);
    
    	return dtTyped;
    }
