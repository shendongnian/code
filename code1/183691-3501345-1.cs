    private void UpdateRowEventHandler(object sender, EventArgs e)
    {
        AdditionalSupport.UpdateASRecord(year, studentID, 
            FromDB<Boolean?>(grdMainLevel1.GetFocusedRowCellValue(colASRequiresSupport)));
    }
    
    internal static void UpdateASRecord(
            string year,
            string studentID,
            bool? requiresSupport)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();
    
        parameters.Add(new SqlParameter("@year", SqlDbType.Char, 4) { Value = year });
        parameters.Add(new SqlParameter("@student_id", SqlDbType.Char, 11) { Value = studentID });
        parameters.Add(new SqlParameter("@requires_support", SqlDbType.Bit) { Value = ToDB(requiresSupport) });
    
        //execute sql query here to do update
    }
