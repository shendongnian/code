    //call SQL helper class to get initial data 
    DataTable dt = sql.ExecuteDataTable("sp_MyProc");
    
    dt.Columns.Add("NewColumn", typeof(System.Int32));
    
    foreach(DataRow dr in dt.Rows)
    {
        //need to set value to NewColumn column
        dr["NewColumn"] = 0;   // or set it to some other value
    }
    // possibly save your Dataset here, after setting all the new values
