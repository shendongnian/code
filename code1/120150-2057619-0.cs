    string sql_Phone = "SELECT Phone_Number FROM Contact_Details WHERE Emp_ID = @EmpID";
    using (SqlConnection cn2 = new Sqlconnection(databaseConnectionString))
    using (SqlCommand cmd_Phone = new SqlCommand(sql_Phone, cn2))
    {
        cmd_Phone.Parameters.Add("@EmpID", SqlDbType.Int);
        cn2.Open();
        
        while (dr_SignUp.Read())
        {
            List<string> arrPhone = new List<string>();
            cmd_Phone.Parameters[0].Value = dr_SignUp["Emp_ID"];
               
            using (SqlDataReader dr_Phone = cmd_Phone.ExecuteReader())
            {
                while (dr_Phone.Read())
                {
                    arrPhone.Add(dr_Phone["Phone_Number"].ToString());
                }
            }
