    //call SQL helper class to get initial data 
    DataTable dt = sql.ExecuteDataTable("sp_MyProc");
    
    dt.Columns.Add("MyRow", type(System.Int32));
    
    for(DataRow dr in dt.Rows)
    {
        //need to set value to MyRow column
        dr["MyRow"] = 0;   // or set it to some other value
    }
    // possibly save your Dataset here, after setting all the new values
