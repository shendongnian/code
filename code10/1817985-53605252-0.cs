     private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    string user = txtEmail.Text;
                    string pass = ToSHA2569(txtPassword.Text);
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[Register] where Email=@Email and Password=@Password", sqlcon);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", ToSHA2569(txtPassword.Text));
                    var isCorrectPassword = cmd.ExecuteScalar();
                    if ((int)isCorrectPassword == 1)
                    {
                        sqlcon.Close();
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        sqlcon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblWrong.Text = "Something went wrong please try again later";
            }
        }
