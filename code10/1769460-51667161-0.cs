              private static int loginCounter;
              private static string UserName;
        
              private void btn_login_Click(object sender, EventArgs e)
            {
                    var obj = new Usercontrols.SIMSMain();
                    obj.Dock = DockStyle.Fill;
            
                    conn.Open();
                    SqlCommand selectCommand = new SqlCommand("Select * from admin_access where Username=@admin AND Password=@eyelab",conn);
                    selectCommand.Parameters.AddWithValue("@admin", txt_username.Text);
                    selectCommand.Parameters.AddWithValue("@eyelab", txt_password.Text);
                    SqlDataReader dataReader;   
                    dataReader = selectCommand.ExecuteReader();
                    var count = 0;
            
                    while (dataReader.Read())
                    {
                        count = count + 1;
                    }
                if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_password.Text))
                {
                    MetroMessageBox.Show(this, "Please input the Required Fields", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                if (count == 0 && UserName == txt_username.Text)
                {
               loginCounter += 1;
                 }
                if(loginCounter  >= 3)
                {
         MetroMessageBox.Show(this, "You have exceeded maximum login attempts.", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
    UserName == txt_username.Text
                    if (count == 1)
                    {
    // Here reset the login counter, since the password is right
    loginCounter = 0;
    UserName = "";
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
                        MetroMessageBox.Show(this, "Invalid Username/Password", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }    
                }
       
                conn.Close();
            }
