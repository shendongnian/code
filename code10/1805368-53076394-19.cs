    SqlCommand cmd = new SqlCommand("SetTestProjectTemplateSectionFromTable", con);
    cmd.CommandType = CommandType.StoredProcedure;
    
    DataTable tbl = new DataTable();
    tbl.Columns.Add("ProjectID", typeof(int));
    tbl.Columns.Add("ProjectTemplateID", typeof(int));
    tbl.Columns.Add("SectionID", typeof(int));
    tbl.Columns.Add("IsActive", typeof(boolean)); // Check it because I don't remember how to use type bit here
    tbl.Columns.Add("SectionOrderNumber", typeof(int));
    
    tbl.Rows.Add(1,1,1,true,111);
    tbl.Rows.Add(1,1,2,true,222);
    
    cmd.Parameters.AddWithValue("@ProjectTemplateSectionDate", tbl);
    
    cmd.ExecuteNonQuery();
