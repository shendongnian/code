    using (SqlConnection con = new SqlConnection(Base.GetConnection))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM TableFatherMaster WHERE EmployeeNo=@EmployeeNo ", con))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@EmployeeNo", ddFatherEmployeeNumber.SelectedValue);
            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            ddEmployeeFatherName.DataSource = r;
            // set text and value fields
            ddEmployeeFatherName.DataTextField = "Name";
            ddEmployeeFatherName.DataValueField = "Id";
            ddEmployeeFatherName.DataBind();
        }
    }
