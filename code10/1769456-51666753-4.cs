    Timer loginAttempsTimeOut;
    Dictionary<string, int> loginAttempsPerUser = new Dictionary<string,int>();
    Dictionary<string, DateTime> loginAttemptsViolated = new Dictionary<string, DateTime>();
    int TimeOutInMinutes = 15;
    
    private void SetTimer()
    {
        loginAttempsTimeOut = new Timer();
        loginAttempsTimeOut.Interval = 1000 * 60; // check timeout every 1 mins
        loginAttempsTimeOut.Tick += LoginAttempsTimeOut_Tick;
    }
    
    // set a timer, and if login timeout for each user is elapsed,
    // allow user to try login again
    private void LoginAttempsTimeOut_Tick(object sender, EventArgs e)
    {
        foreach(var user in loginAttemptsViolated.Keys)
        {
            loginAttemptsViolated.TryGetValue(user, out var date);
            TimeSpan span = DateTime.Now.Subtract(date);
            if(span.TotalMinutes > TimeOutInMinutes)
            {
                loginAttempsPerUser[user] = 0;
                loginAttemptsViolated.Remove(user);
                loginAttempsPerUser.Remove(user); 
            }
        }
    }
    
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
            var count = 0;
    
            while (dataReader.Read())
            {
                count = count + 1;
            }
            if(loginAttemptsViolated[txt_username.Text] != null)
            {
               MetroMessageBox.Show("Login attempts is more than 3.");
            }
            else if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_password.Text))
            {
                MetroMessageBox.Show(this, "Please input the Required Fields", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (count == 1)
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
                    //if user cannot login, increase login attempts
                    if(!loginAttempsPerUser.ContainsKey(txt_username.Text))
                       loginAttempsPerUser.Add(txt_username.Text, 1);
                    
                    loginAttempsPerUser[txt_username]++;
                    if(loginAttempsPerUser[txt_username.Text] > 2)
                    {
                        // if login attempts > 2 set a 15 min timeout till user 
                        // cant login
                        if(!loginAttemptsViolated.ContainsKey(txt_username.Text))
                           loginAttemptsViolated.Add(txt_username.Text, DateTime.Now);
                    }
                    MetroMessageBox.Show(this, "Invalid Username/Password", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            conn.Close();
        }
    
    }
