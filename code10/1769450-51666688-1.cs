	int failAttempt  = 0;
	private void btn_login_Click(object sender, EventArgs e)
	{
		// Step 1: Check if inputs are valid
		if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_password.Text))
		{
			MetroMessageBox.Show(this, "Please input the Required Fields", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		
		
		// Step 2: Check if there is one user with this password/login
		var obj = new Usercontrols.SIMSMain();
		obj.Dock = DockStyle.Fill;
		conn.Open();
		SqlCommand selectCommand = new SqlCommand("Select * from admin_access where Username=@admin AND Password=@eyelab",conn);
		selectCommand.Parameters.AddWithValue("@admin", txt_username.Text);
		selectCommand.Parameters.AddWithValue("@eyelab", txt_password.Text);
		SqlDataReader dataReader = selectCommand.ExecuteReader();
		
		if(dataReader.Read())
		{   //Sucess
			failAttempt  = 0;
			
			MetroMessageBox.Show(this, "Login Successful", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Hide();
			this.Parent.Controls.Add(obj);
                        
		}
		else { // Fail
			failAttempt ++;
		}
		conn.Close();
           
                // Step 3: Fail Handle
		if (failAttempt == 3)
		{
			MetroMessageBox.Show(this, "Super Attempt", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else if ( failAttempt > 0)
		{
			MetroMessageBox.Show(this, "Invalid Username/Password", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}   
