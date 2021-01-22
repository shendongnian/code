    DataTable dt1 = null; DataTable dt2 = new DataTable();
    
    for (int i = 0; i < dt3.Rows.Count; i++) 
    {
    
        // here  "strSQL" is build which changes on the "i" value                  
    
        dt1 = GetDataTable(strSQL); // this returns a table with single Row
    
        dt2.Merge(dt1,true);
    }
