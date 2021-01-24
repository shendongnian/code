            MySqlConnection sqlcon = new MySqlConnection(@"server=xx.xx.xx.xx;user id=user;password=password;persistsecurityinfo=False;database=website;sslmode=None;");
            string query = "Select * from users Where username= '" + tbUser.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count > 0)
            {
                MessageBox.Show("Username exista!");
            }
            else
            {
                if(tbUser.Text == "" | tbPass.Text == ""){
                    MessageBox.Show("Completati campurile corespunzator !");
                }
                else
                {
                    try
                    {
                        string commString = "INSERT INTO users (username, password, permissions, homedir) VALUES (@val1, @val2, @val3, @val4)";
                        string constring = @"server=xx.xx.xx.xx;user id=user;password=password;persistsecurityinfo=False;database=website;sslmode=None;";
                        string savedPasswordHash = CryptSharp.Crypter.Phpass.Crypt(tbPass.Text, salt);
                        
                        using (MySqlConnection conn = new MySqlConnection(constring))
                        {
                            using (MySqlCommand comm = new MySqlCommand())
                            {
                                comm.Connection = conn;
                                comm.CommandText = commString;
                                comm.Parameters.AddWithValue("@val1", tbUser.Text);
                                comm.Parameters.AddWithValue("@val2", savedPasswordHash);
                                comm.Parameters.AddWithValue("@val3", "rwu");
                                comm.Parameters.AddWithValue("@val4", "/var/www/repository/HOME");
                                conn.Open();
                                comm.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        MessageBox.Show("Inregistrare reusita!");
                        tbPass.Text = null;
                        sqlcon.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Eroare la inregistrare. Contactati administratorul !");
                    }
                }
            }
