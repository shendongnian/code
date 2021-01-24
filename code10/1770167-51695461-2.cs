    string sqlStr2 = @"Select assignID, COUNT(assignID) as Totals 
                      from assign where userId=@name
                      GROUP BY assignID";
    .....
    MySqlDataReader reader1 = cmd3.ExecuteReader();
    if (reader1.HasRows)
    {
        while (reader1.Read())
        {
            if ((int)reader1["Totals"] > 2) 
            {
                // Not clear what you want to do if Totals > 2
                txtAssignID1.Text += "Hello";
            }
            else
            {
                btnStart.IsEnabled = true;
                string assignID = (reader1["assignID"].ToString());
                txtAssignID1.Text += "Your exercise ID is: " + assignID;
            }
        }  
    }
    else
    {
        txtAssignID1.Text += "You have not been assigned any exercise ID";
        txtAssignID.IsEnabled = false;
    }
  
