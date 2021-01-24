        int count = 1;
        private void btn_login_Click(object sender, EventArgs e)
        {
            var obj = new Usercontrols.SIMSMain();
            obj.Dock = DockStyle.Fill;
            conn.Open();
            SqlCommand selectCommand = new SqlCommand("Select * from admin_access where Username=@admin AND Password=@eyelab", conn);
            selectCommand.Parameters.AddWithValue("@admin", txt_username.Text);
            selectCommand.Parameters.AddWithValue("@eyelab", txt_password.Text);
            SqlDataReader dataReader;
            dataReader = selectCommand.ExecuteReader();
            var counter = 0; //to check if there is data
            while (dataReader.Read())
            {
                counter++;
            }
            if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_password.Text))
            {
                MetroMessageBox.Show(this, "Please input the Required Fields", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (counter == 1)
                {
                    MetroMessageBox.Show(this, "Login Successful", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    this.Parent.Controls.Add(obj);
                }
                else if (count == 3)
                {
                    count++;
                    MetroMessageBox.Show(this, "Super Attempt", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    count++;
                    MetroMessageBox.Show(this, "Invalid Username/Password", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            conn.Close();
        }
