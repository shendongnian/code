    public static DataTable DisplayTableColumns(string tt) 
    { 
        Datatable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        try 
        { 
            da.Fill(dt); 
        } 
        catch (Exception ex) 
        { 
            errorMsg = ex.Message; 
        } 
        
        string temp;
        foreach(DataRow row in dt.Rows)
        {
            foreach(DataColumn column in dt.Columns)
            {
                temp = (row[column]);  // use your breakpoint here
            }
        }
        return dt; 
    } 
