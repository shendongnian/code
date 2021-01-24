    protected void userRegister(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["Khulna_website"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(constr))
        {
            string insertQuery = "insert into dbo.users(user_f_name,user_l_name,user_password,user_email,user_age, user_gender) values (@First_Name, @Last_Name, @Regi_Password, @Regi_Email, @Age, @Gender);";
            SqlCommand com = new SqlCommand(insertQuery, connection);
            connection.Open();
            com.Parameters.AddWithValue("@First_Name", First_Name.Text);
            com.Parameters.AddWithValue("@Last_Name", Last_Name.Text);
            com.Parameters.AddWithValue("@Regi_Password", Regi_Password.Text);
            com.Parameters.AddWithValue("@Regi_Email", Regi_Email.Text);
            com.Parameters.AddWithValue("@Age", Age.Text);
            com.Parameters.AddWithValue("@Gender", Gender.SelectedValue);
                
            com.ExecuteNonQuery();
        }            
    }
