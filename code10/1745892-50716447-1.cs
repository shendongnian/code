    private void buttonLogin_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(textBoxUserName.Text))
        {
            MessageBox.Show("Username can't be empty");
            textBoxUserName.Focus();
        }
        else if (String.IsNullOrEmpty(textBoxPassword.Text))
        {
            MessageBox.Show("Password can't be empty");
            textBoxPassword.Focus();
        }
        else
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand SelectCommand = new SqlCommand("SELECT * FROM Users WHERE  
                username ='" + textBoxUserName.Text.Trim() + "' and password= '" + textBoxPassword.Text.Trim() + "'");
                SqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                string userRole = string.Empty;
                while (myReader.Read())
                {
                    count = count + 1;
                    userRole = myReader["userrank"].ToString();
                }
    
                if (count == 1)
                {
    
                    if (userRole =="admin" )
                    {
                        Form1 form = new Form1();
                        this.Hide();
                        form.Show();
                        con.Close();
                    }
                    else
                    {
                        UI ui = new UI();
                        this.Hide();
                        ui.Show();
                        con.Close();
                    }
                    myReader.Close();
                }
                else
                {
                    MessageBox.Show("Check your username or password");
                    con.Close();
                }           
            } 
        }      
    }
