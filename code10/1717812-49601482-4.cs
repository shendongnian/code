    public List<Emloyee> GetEmployees()
    {
        connection();
        List<Emloyee> employeelist = new List<Emloyee>();
    
    
        SqlCommand cmd = new SqlCommand("GetEmployeeDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sd = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
    
    
        con.Open();
        sd.Fill(dt);
        con.Close();
    
        foreach (DataRow dr in dt.Rows)
        {
            employeelist.Add(
                new Emloyee
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    GenderName = Convert.ToString(dr["GenderName"]),
                    DepartmentName = Convert.ToString(dr["DepartmentName"])
                    DepartmentId = Convert.ToInt32(dr["DepartmentId "])
                });
        }
        return employeelist;
    }
