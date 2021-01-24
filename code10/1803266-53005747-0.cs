    public DataTable YourMethodName()
    {
        DataTable dt = new DataTable();
    
        SQLDataManager sql = new SQLDataManager(false);
                string query = "SELECT * FROM member_case_management where panumber like '%'+ @value +'%'";
    
        sql.AddParamAndValue("@value", searchvalue);
    
        dt = sql.GetDataset(query, CommandType.Text).Tables[0];
    
        return dt;
    }
