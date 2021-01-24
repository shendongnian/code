            try
            {
                Login lognin = new Login();
                lognin.Show();
                this.Hide();
                using (OleDbConnection conect = new OleDbConnection(connectionString))
                {
                    conect.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conect;
                    command.CommandText =
                               "insert into Sign_Up 
                                  ([FirstName],[LastName], [UserName],[Password]) 
                             values('"
                              + First.Text+ "','" 
                              + Last.Text + "','" 
                              + User.Text + "','" 
                              + Pass.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Sign Up Succsaesful"); 
	            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sign up error:{ex.message}");
            }
