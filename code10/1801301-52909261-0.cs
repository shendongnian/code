    public void updateDepartmentList()
    {
        refresh_DataGridView();
    
        SqlCommand cmd = new SqlCommand("SelectComoboxData_SP", con);
        cmd.CommandType = CommandType.StoredProcedure;
    
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        com_boxDepartment.DataSource = dt;
        com_boxDepartment.DisplayMember = "dep_Name";
        com_boxDepartment.ValueMember = "dep_Id";
    }
