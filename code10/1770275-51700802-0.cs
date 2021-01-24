    string sqlStr = @"SELECT patpro.PATNAME FROM patpro INNER JOIN useform 
                      ON useform.USER_ID = patpro.USERID 
                      WHERE useform.USER_ID = @name AND useform.USER_PWD = @password";
    cmd.Parameters.AddWithValue("@name", txtValue.Text);
    cmd.Parameters.AddWithValue("@password", txtPassword.Password);
    cmd.CommandText = sqlStr;
    cmd.Connection = connection;
    
    connection.Open();
    MySqlDataReader login = cmd.ExecuteReader();
    
    if (login.HasRows)
    {
        // read value inside the loop, because MySqlDataReader is forward-only
        while (login.Read())
        {
            string name = login["PATNAME"].ToString();
            txtAssignID1.Text = "Login verified. Hi, " + name + "\n";
        }
    }
