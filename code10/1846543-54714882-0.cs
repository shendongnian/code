            try
            {
                connection.Open();
                SqlCommand commandLogin = new SqlCommand("select * from Proprietário", connection);
                SqlDataReader reader = commandLogin.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(5).ToString() == txtUser.Text && reader.GetValue(6).ToString() == txtPass.Text)
                    {
                        User = txtUser.Text;
                        tipo = reader.GetBoolean(7);
                        tssl_Login.Text = "Login feito com sucessso!";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
