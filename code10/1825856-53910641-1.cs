    string userLogat = tbUser.Text;
                MySqlConnection sqlcon = new MySqlConnection(@"server=xx.xx.xx.xx;user id=user;password=password;persistsecurityinfo=False;database=website;sslmode=None;");
                string query = "Select * from users Where username= '" + tbUser.Text + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    string savedPasswordHash = dtbl.Rows[0][3].ToString();
                    if (ValidatePassword(tbPass.Text, savedPasswordHash, salt))
                    {
                        MessageBox.Show($"Wellcome {tbUser.Text} !");
                        FormMain openMain = new FormMain(userLogat);
                        openMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show($"Password for  {userLogat} error.");
                    }
                }
                else
                {
                    MessageBox.Show($"Username error!");
                }
                sqlcon.Close();
