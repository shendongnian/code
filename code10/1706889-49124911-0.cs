    protected void drpEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
            {
                String connString = ConfigurationManager.ConnectionStrings["HRPlannerConnectionString1"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString); 
                string result = "SELECT EmployeeName from Employees WHERE EmployeeID=@empID";
              
                SqlCommand showresult = new SqlCommand(result, conn);
          showresult.Parameters.AddWithValue("@empID",drpEmployeeName.SelectedItem.Value);
                conn.Open();
                lblEmployee.Text = showresult.ExecuteScalar().ToString();
                conn.Close();
            }
