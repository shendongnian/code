    SqlCommand scmd = new SqlCommand("select count ([User Level]) as UserCount, [User Level] from tblUsers where [User Name]=@usr and Password=@pwd", scn);
    scmd.Parameters.Clear();
    scmd.Parameters.AddWithValue("@usr", txtUser.Text);
    scmd.Parameters.AddWithValue("@pwd", txtPass.Text);            
    scn.Open();
    string userLabel = "";
    int userCount = 0;
    try
    {
          SqlDataReader reader = cmd.ExecuteReader();
          if (reader.Read())
          {
            userLabel = (string)reader["User Level"];
            userCount = (int)reader["UserCount"];
          }
     }
     catch (Exception ex)
     {
          //do something here if it fails. 
     }
    if (userCount == 1) 
    {
         MessageBox.Show("You are granted with access.");
         //rest of your code....
    }
