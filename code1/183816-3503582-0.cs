    public string PasswordChange(string userName, string oldPass, string newPass)
    {
        using(SqlConnection sqlConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LoginDb"].ConnectionString))
       {
        string sqlToConfirmOldPass =
          "SELECT password FROM LoginAccount WHERE username = @userName";
        string sqlToUpdatePassword =
          "UPDATE LoginAccount SET password = @newPass WHERE username = @userName";
        SqlCommand confirmOldPass = new SqlCommand(sqlToConfirmOldPass, sqlConnection);
        confirmOldPass.Parameters.AddWithValue("@userName", userName);
        SqlCommand updatePassword = new SqlCommand(sqlToUpdatePassword, sqlConnection);
        updatePassword.Parameters.AddWithValue("@newPass", newPass);
        updatePassword.Parameters.AddWithValue("@userName", userName);
        [Rest of your code goes here]
       }
    }
