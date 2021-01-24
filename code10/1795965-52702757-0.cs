    private static int count = 0;   
    private void btn_login_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_password.Text))
        {
            MetroMessageBox.Show(this, "Please input the Required Fields", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
            string Results = CheckLogin(txt_username.Text, txt_password.Text)
            //**  code to handle results from db query **//
            if (Results.Equals("Invalid"))
            {
                // handle bad password
                count++;
            }
            else
            {
                // handle good password
            }
        }    
    }
    private string CheckLogin(string User, string Pass)
    {
        string returnstring = "Invalid";
        using (var con = SQLConnection.GetConnection())
        {
            var selectCommand = new SqlCommand("Select * from Users_Profile where Username= @Username and Password= @Password", con);           
            selectCommand.Parameters.AddWithValue("@Username", User);
            selectCommand.Parameters.AddWithValue("@Password", Pass);
            SqlDataReader dataReader;
            dataReader = selectCommand.ExecuteReader();
            var loginSuccess = false;
            while (dataReader.Read())
            {
                loginSuccess = true;
                returnstring = dataReader["Usertype"].ToString();
            }
        return returnstring;
    }
