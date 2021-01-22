    private SqlDbType GetDBType(System.Type theType)
    {
    	SqlClient.SqlParameter p1;
    	System.ComponentModel.TypeConverter tc;
    	p1 = new SqlClient.SqlParameter();
    	tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
    	if (tc.CanConvertFrom(theType)) {
    		p1.DbType = tc.ConvertFrom(theType.Name);
    	}
    	else {
    		//Try brute force
    		try {
    			p1.DbType = tc.ConvertFrom(theType.Name);
    		}
    		catch (Exception ex) {
    			//Do Nothing
    		}
    	}
    	return p1.SqlDbType;
    }
