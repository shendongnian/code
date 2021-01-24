    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ToString()) 
    {
       using (SqlCommand cmd = new SqlCommand("insert into Epersonal (Emp_Id,NIC,Gender,B_day,Nationality,Marital_status,Work_Role)values(@Emp_Id,@NIC,@Gender,@B_day,@Nationality,@Marital_status,@Work_Role)", con))
       {
              cmd.Parameters.AddWithValue("@Emp_Id", TextBox1.Text);
              cmd.Parameters.AddWithValue("@NIC", nic.Text);
              cmd.Parameters.AddWithValue("@Gender", DropDownList2.SelectedItem.Value);
              cmd.Parameters.AddWithValue("@B_day", bday.Text);
              cmd.Parameters.AddWithValue("@Nationality", ntionl.Text);
              cmd.Parameters.AddWithValue("@Marital_status", DropDownList3.SelectedItem.Value);
              cmd.Parameters.AddWithValue(" @Work_Role", DropDownList1.SelectedItem.Value);
              con.Open();
              Response.Write("cannection made");
              cmd.ExecuteNonQuery();
      }
    }
    Response.Redirect("log.aspx");
