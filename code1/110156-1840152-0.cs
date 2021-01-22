    DataTable dt1 = null; DataTable dt2 = null;
    
    for (int i = 0; i < dt3.Rows.Count; i++) 
    {
    
        // here  "strSQL" is build which changes on the "i" value                  
    
        dt1 = GetDataTable(strSQL); // this returns a table with single Row
    
        if(dt2 == null) 
        {
           dt2 = dt1.Clone();
        }
    
        dt2.Merge(dt1,true);
    }
