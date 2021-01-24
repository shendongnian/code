            try
            {
                using (OleDbConnection conect = new OleDbConnection(connectionString))
                {
                    conect.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conect;
                    command.CommandText = "select * from Sign_Up where UserName='" + User_Name.Text + "' and Password='" + Password.Text + "'";
                    OleDbDataReader reader = command.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("User Name and Password Are Correct ");
                        Admin admin = new Admin();
                        admin.Show();
                        this.Hide();
                    }
                    if (count > 1)
                    {
                        MessageBox.Show("Dublicated UserName And Password ");
                    }
                    else
                    {
                        MessageBox.Show("User Name and Password Are Not Correct ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login form error: {ex.Message}");
            }
