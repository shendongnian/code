    class DataTableHelper {
    public DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName)
    {	
            DataTable dt = new DataTable(TableName);
            dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
    			
            object LastValue = null; 
            foreach (DataRow dr in SourceTable.Select("", FieldName))
            {
                if (  LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])) ) 
                {
                    LastValue = dr[FieldName]; 
                    dt.Rows.Add(new object[]{LastValue});
                }
            }
            return dt;
    }
    private bool ColumnEqual(object A, object B)
    {
    	
            // Compares two values to see if they are equal. Also compares DBNULL.Value.
            // Note: If your DataTable contains object fields, then you must extend this
            // function to handle them in a meaningful way if you intend to group on them.
    			
            if ( A == DBNull.Value && B == DBNull.Value ) //  both are DBNull.Value
                return true; 
            if ( A == DBNull.Value || B == DBNull.Value ) //  only one is DBNull.Value
                return false; 
            return ( A.Equals(B) );  // value type standard comparison
    }
    }
