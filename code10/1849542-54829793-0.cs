`
private void signInButton_Click(object sender, EventArgs e)
        {
            DataProcedures data = new DataProcedures();
            User userInfo = new User(usernameTextbox.Text, passwordTextbox.Text);
            userInfo.userId = data.verifyUser(userInfo);
            if (userInfo.userId != -1)
            {
                AppWindow a = new AppWindow();
                 a.Show();
            }
            else
            {
                errorLabel.Show();
            }
        }
public int verifyUser(User userInfo)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            int userId = -1;
            string returnedUserName;
            string returnedPassword;
            try
            {
                conn.Open();
                MySqlCommand checkUserNameCmd = conn.CreateCommand();
                checkUserNameCmd.CommandText = "SELECT EXISTS(SELECT userName FROM user WHERE userName = @username)";
                checkUserNameCmd.Parameters.AddWithValue("@username", userInfo.username);
                returnedUserName = checkUserNameCmd.ExecuteScalar().ToString();
                MySqlCommand checkPasswordCmd = conn.CreateCommand();
                checkPasswordCmd.CommandText = "SELECT EXISTS(SELECT password FROM user WHERE BINARY password = @password AND userName = @username)";//"BINARY" is used for case sensitivity in SQL queries
                checkPasswordCmd.Parameters.AddWithValue("@password", userInfo.password);
                checkPasswordCmd.Parameters.AddWithValue("@username", userInfo.username);
                returnedPassword = checkPasswordCmd.ExecuteScalar().ToString();
                if (returnedUserName == "1" && returnedPassword == "1")
                {
                    MySqlCommand returnUserIdCmd = conn.CreateCommand();
                    returnUserIdCmd.CommandText = "SELECT userId FROM user WHERE BINARY password = @password AND userName = @username";
                    returnUserIdCmd.Parameters.AddWithValue("@password", userInfo.password);
                    returnUserIdCmd.Parameters.AddWithValue("@username", userInfo.username);
                    userId = (int)returnUserIdCmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown verifying user: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return userId;
        }
`
Hope this helps.
