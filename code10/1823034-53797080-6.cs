      protected void btnLogin_Click(object sender, EventArgs e)
            {
                using (SqlConnection sqlCon = new SqlConnection("server = localhost; user id = root; database = bot");
    
                {
                    sqlCon.Open();
                    string query =  "Select * from license Where user = '" + textBox1.Text.Trim() + "' and pwd = '" + textBox2.Text.Trim() + "'";
         
           SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@user",textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@pwd", textBox2.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["user"] = textBox1.Text.Trim();
                    Response.Redirect("Dashboard.aspx");
                }
                else { lblErrorMessage.Visible = true; }
            }
        }
