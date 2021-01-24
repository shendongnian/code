     public void GetEmployees1()
        {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                if (Session["EmployeeLevelID"].ToString() == "2" && Session["EmployeeDepartmentID"].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("GetEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", Session["EmployeeID"].ToString());
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    lvEmployees.DataSource = ds;
                    lvEmployees.DataBind();
                     
                }
                con.Close();
            }
        }
