    string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    using (SqlConnection con = new SqlConnection(ConnectionString))
    {
    //Create the SqlCommand object
    SqlCommand cmd = new SqlCommand(“spAddEmployee”, con);
    
    //Specify that the SqlCommand is a stored procedure
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    //Add the input parameters to the command object
    cmd.Parameters.AddWithValue(“@Name”, txtEmployeeName.Text);
    cmd.Parameters.AddWithValue(“@Gender”, ddlGender.SelectedValue);
    cmd.Parameters.AddWithValue(“@Salary”, txtSalary.Text);
    
    //Add the output parameter to the command object
    SqlParameter outPutParameter = new SqlParameter();
    outPutParameter.ParameterName = “@EmployeeId”;
    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
    outPutParameter.Direction = System.Data.ParameterDirection.Output;
    cmd.Parameters.Add(outPutParameter);
    
    //Open the connection and execute the query
    con.Open();
    cmd.ExecuteNonQuery();
    
    //Retrieve the value of the output parameter
    string EmployeeId = outPutParameter.Value.ToString();
    }
